📅 EventCalendar - ASP.NET MVC & FullCalendar

Bu proje, ASP.NET MVC mimarisi üzerinde FullCalendar kütüphanesini kullanarak dinamik, sürükle-bırak destekli ve veritabanı entegreli bir etkinlik yönetim sistemi sunar. Projenin temel amacı, kullanıcıların etkinliklerini görsel bir takvim üzerinde yönetmelerini sağlarken, arka planda veri tutarlılığını ve performanslı senkronizasyonu korumaktır.

🚀 Öne Çıkan Özellikler
Dinamik Kategori Yönetimi: Veritabanından rastgele veya kullanım durumuna göre getirilen sürükle-bırak kategoriler.

Akıllı AJAX Senkronizasyonu: Sayfayı yenilemeden etkinlik ekleme, güncelleme ve silme işlemleri.

Gelişmiş Renk Eşleştirme: Bootstrap sınıf isimlerini (bg-danger vb.) FullCalendar'ın anlayacağı Hex kodlarına dönüştüren yardımcı fonksiyonlar.

Kilit (Mutex) Mekanizması: JavaScript tarafında aynı anda birden fazla kayıt oluşturulmasını engelleyen özel kilit sistemleri.

🛠️ Teknik Detaylar ve Yapılan İyileştirmeler
1. Sürükle-Bırak Senkronizasyon Çözümü (Görsel Tutarlılık)
FullCalendar'da harici bir elementi takvime bıraktığınızda, kütüphane otomatik olarak "geçici" bir etkinlik oluşturur. Bu durum, AJAX ile veritabanına kayıt atılırken takvimde aynı etkinliğin iki kez görünmesine (biri veritabanından gelen, diğeri FullCalendar'ın kendi oluşturduğu) neden olabiliyordu.

Çözüm: eventReceive olayında FullCalendar'ın oluşturduğu geçici kopyayı remove() ile sildik ve AJAX'tan dönen gerçek veritabanı ID'si ile yeni, "resmi" etkinliği addEvent ile takvime ekledik. Böylece kullanıcı görsel bir takılma yaşamadan veritabanıyla tam uyumlu bir deneyim elde etti.

2. Bootstrap Renk Dönüşümü (getBootstrapColor)
AdminLTE ve Bootstrap temalarında kullanılan renk sınıfları (bg-primary, bg-success) FullCalendar tarafından doğrudan tanınmaz. Projede yazdığımız yardımcı fonksiyon ile bu sınıflar gerçek zamanlı olarak Hex kodlarına çevrilerek takvimin görsel bütünlüğü korunmuştur.

3. Kayıt Çakışmalarının Önlenmesi (isProcessing)
Hızlı kullanıcı etkileşimlerinde veritabanına mükerrer (çift) kayıt atılmasını önlemek için JavaScript tarafında bir "İşlem Kilidi" (Processing Lock) mekanizması kurulmuştur. Bir AJAX isteği tamamlanmadan ikincisinin tetiklenmesi bu sayede engellenmiştir.

4. Modal ve Erişilebilirlik Yönetimi
Modal üzerinden silme ve güncelleme işlemlerinde karşılaşılan aria-hidden hataları ve "takılı kalan backdrop" sorunları, özel bir temizlik fonksiyonu (closeModalCleanly) ile çözülmüştür. İşlem sonrası odaklanılan element ve modal kalıntıları DOM'dan tamamen temizlenmektedir.

🏗️ Kullanılan Teknolojiler
Backend: ASP.NET MVC, Entity Framework (Code First), C#

Frontend: FullCalendar v5+, jQuery, Bootstrap 4, AdminLTE 3

Database: MS SQL Server

📂 Proje Yapısı
EventController: Etkinlik ve kategori verilerini JSON formatında sunan API katmanı.

Partial Scripts: Karmaşıklığı önlemek adına JavaScript mantığının taşındığı modüler yapı.

Context: Entity Framework veritabanı bağlantı ve tablo tanımlamaları.
