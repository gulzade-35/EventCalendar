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
