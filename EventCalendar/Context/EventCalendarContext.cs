using EventCalendar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventCalendar.Context
{
    public class EventCalendarContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}