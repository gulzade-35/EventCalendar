📅 **EventCalendar - ASP.NET MVC & FullCalendar**

Bu proje, ASP.NET MVC mimarisi üzerinde FullCalendar kütüphanesini kullanarak dinamik, sürükle-bırak destekli ve veritabanı entegreli bir etkinlik yönetim sistemi sunar. Projenin temel amacı, kullanıcıların etkinliklerini görsel bir takvim üzerinde yönetmelerini sağlarken, arka planda veri tutarlılığını ve performanslı senkronizasyonu korumaktır.

🚀 **Öne Çıkan Özellikler**

Dinamik Kategori Yönetimi: Veritabanından rastgele veya kullanım durumuna göre getirilen sürükle-bırak kategoriler.

Akıllı AJAX Senkronizasyonu: Sayfayı yenilemeden etkinlik ekleme, güncelleme ve silme işlemleri.

Gelişmiş Renk Eşleştirme: Bootstrap sınıf isimlerini (bg-danger vb.) FullCalendar'ın anlayacağı Hex kodlarına dönüştüren yardımcı fonksiyonlar.

Kilit (Mutex) Mekanizması: JavaScript tarafında aynı anda birden fazla kayıt oluşturulmasını engelleyen özel kilit sistemleri.

🛠️ **Teknik Detaylar ve Yapılan İyileştirmeler**

|Katman / Amaç          | Teknoloji / Yaklaşım       
|-------------    |------------------          
| Eşzamanlılık Kontrolü        | 	isProcessing & Mutex Logic: Hızlı sürükle-bırak işlemlerinde veritabanına mükerrer (çift) kayıt atılmasını engelleyen kilit mekanizması.     
| Veri Senkronizasyonu        | 	Optimistic UI vs Real-time Sync: Geçici kopyaların (shadow events) temizlenip, sunucu onaylı gerçek verilerin takvime dinamik enjeksiyonu.  
| Renk Adaptasyonu    | 	Dynamic CSS Bridge: Bootstrap class yapılarını FullCalendar'ın anlayacağı Hex kodlarına dinamik olarak haritalayan yardımcı katman. 

🏗️ Kullanılan Teknolojiler

|Katman          | Teknoloji / Kütüphane        | Açıklama                   |
|-------------    |------------------           |------------------  |
| Backend         | 	ASP.NET MVC (C#)         | Uygulamanın temel mimarisi ve sunucu tarafı mantığı.
| Database    | Entity Framework (Code First)       | Veritabanı modelleme ve ORM (Object-Relational Mapping).
| Database Server    | MS SQL Server             | Verilerin güvenli ve performanslı bir şekilde saklanması.
| Frontend Framework          | Bootstrap 4 & AdminLTE 3        | Modern, responsive ve şık kullanıcı arayüzü tasarımı.
| Calendar Engine          | FullCalendar v5  | Etkinliklerin takvim üzerinde yönetilmesini sağlayan çekirdek yapı.
| Scripting     | jQuery & JavaScript  | Dinamik içerik yönetimi, DOM manipülasyonu ve AJAX işlemleri.
| Date Handling     | Moment.js  | Tarih ve saat formatlarının kolayca işlenmesi ve dönüştürülmesi.

📂 **Proje Yapısı**

EventController: Etkinlik ve kategori verilerini JSON formatında sunan API katmanı.

Partial Scripts: Karmaşıklığı önlemek adına JavaScript mantığının taşındığı modüler yapı.

Context: Entity Framework veritabanı bağlantı ve tablo tanımlamaları.

**Ekran Görüntüleri**

![Image](https://github.com/user-attachments/assets/6eb86e77-e945-446b-9ce6-82086ae8584f)

![Image](https://github.com/user-attachments/assets/192e2a34-ea14-4985-a15d-34221001ced1)

![Image](https://github.com/user-attachments/assets/9fb2ce00-e5a1-40a5-8673-3af286414464)

![Image](https://github.com/user-attachments/assets/37e85475-811c-49d5-8981-eda69c8735ef)

![Image](https://github.com/user-attachments/assets/85b1944b-5eab-4511-bf7c-904164f34e38)

![Image](https://github.com/user-attachments/assets/d6e3996d-752e-4d01-944a-0051c446eb5a)

![Image](https://github.com/user-attachments/assets/69c400b4-0189-412b-8871-e68eaf411ffa)

![Image](https://github.com/user-attachments/assets/19ca8c11-b2fd-42a3-bd14-4c0b5d1eb1e9)

![Image](https://github.com/user-attachments/assets/b01dbbfc-03c7-48f1-a0fd-b099274bad98)
