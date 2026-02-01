using EventCalendar.Context;
using EventCalendar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace EventCalendar.Controllers
{
    public class EventController : Controller
    {
        private readonly EventCalendarContext context = new EventCalendarContext();

        // Sayfa ilk açıldığında çalışacak
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EventList()
        {
            var events = context.Events.Include("Category").ToList();
            return View(events);
        }

        [HttpGet]
        public JsonResult GetCategories()
        {
            // 1. Mevcut etkinliklerde kullanılan kategori ID'lerini al
            var usedCategoryIds = context.Events.Select(e => e.CategoryId).Distinct().ToList();

            // 2. ÖNCE: Kullanılmayanlardan RASTGELE 5 tane seç
            var unused = context.Categories
                .Where(c => !usedCategoryIds.Contains(c.CategoryId))
                .OrderBy(c => Guid.NewGuid()) // Rastgele sırala
                .Take(5)
                .ToList();

            // 3. EĞER: Kullanılmayanlar 5'ten az ise, kullanılanlardan tamamla
            if (unused.Count < 5)
            {
                var needed = 5 - unused.Count;
                var extra = context.Categories
                    .Where(c => usedCategoryIds.Contains(c.CategoryId))
                    .OrderBy(c => Guid.NewGuid()) // Kullanılanlar içinde de rastgelelik sağla
                    .Take(needed)
                    .ToList();

                unused.AddRange(extra);
            }

            // JSON sonucunu dön (Daha temiz bir Select ile)
            var result = unused.Select(x => new {
                x.CategoryId,
                x.CategoryName,
                x.CategoryColor
            }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult AddEvent(string title, DateTime start, int categoryId)
        {
            try
            {
                var newEvent = new Event
                {
                    Title = title,
                    StartDate = start,
                    CategoryId = categoryId,
                    EndDate = start // İlk aşamada bitişi başlangıca eşitleyelim
                };

                context.Events.Add(newEvent);
                context.SaveChanges();

                return Json(new { success = true, id = newEvent.EventId });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult AddCategory(string CategoryName, string CategoryColor)
        {
            try
            {
                var category = new Category
                {
                    CategoryName = CategoryName,
                    CategoryColor = CategoryColor
                };
                context.Categories.Add(category);
                context.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // Takvim üzerindeki kayıtlı etkinlikler için

        [HttpGet]
        public JsonResult GetEvents()
        {
            // Veritabanından veriyi çekip Proxy hatasını engellemek için ToList yapıyoruz
            var eventsList = context.Events.AsNoTracking().ToList();

            var categoryColors = context.Categories
                .ToDictionary(x => x.CategoryId, x => x.CategoryColor);

            var result = eventsList.Select(e => new
            {
                id = e.EventId,
                title = e.Title,
                start = e.StartDate?.ToString("yyyy-MM-ddTHH:mm:ss"), // Tarihi garantiye alalım
                end = e.EndDate?.ToString("yyyy-MM-ddTHH:mm:ss"),
                allDay = true,
                backgroundColor = categoryColors.ContainsKey(e.CategoryId) ? categoryColors[e.CategoryId] : "#3788d8",
                borderColor = categoryColors.ContainsKey(e.CategoryId) ? categoryColors[e.CategoryId] : "#3788d8",
                extendedProps = new { categoryId = e.CategoryId }
            }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //[HttpGet]
        //public JsonResult GetEvents()
        //{
        //    var categoryColors = context.Categories
        //        .ToDictionary(x => x.CategoryId, x => x.CategoryColor);

        //    var events = context.Events
        //        .ToList()
        //        .Select(e => new
        //        {
        //            id = e.EventId,
        //            title = e.Title,
        //            start = e.StartDate,
        //            end = e.EndDate,
        //            backgroundColor = categoryColors[e.CategoryId],
        //            borderColor = categoryColors[e.CategoryId],
        //            extendedProps = new
        //            {
        //                categoryId = e.CategoryId
        //            }
        //        });

        //    return Json(events, JsonRequestBehavior.AllowGet);
        //}


        [HttpPost]
        public JsonResult DeleteEvent(int id)
        {
            var evnt = context.Events.Find(id);
            if (evnt != null)
            {
                context.Events.Remove(evnt);
                context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public ActionResult UpdateEventPage(int id)
        {
            var evnt = context.Events
                .Include(x => x.Category)
                .FirstOrDefault(x => x.EventId == id);

            ViewBag.Categories = context.Categories.ToList();

            return View(evnt);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEventPage(Event model)
        {
            var evnt = context.Events.Find(model.EventId);

            evnt.Title = model.Title;
            evnt.CategoryId = model.CategoryId;

            context.SaveChanges();

            return RedirectToAction("EventList");
        }



        [HttpPost]
        public JsonResult UpdateEventTitle(int id, string title)
        {
            var evnt = context.Events.Find(id);
            if (evnt != null)
            {
                evnt.Title = title;
                context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult UpdateEventDate(int id, DateTime start, DateTime? end)
        {
            var evt = context.Events.Find(id);
            if (evt == null) return Json(new { success = false });

            evt.StartDate = start;
            evt.EndDate = end ?? start;
            context.SaveChanges();

            return Json(new { success = true });
        }

    }
}