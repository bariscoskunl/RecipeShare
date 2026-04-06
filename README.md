Haklısın Barış, veritabanı kurulumu ve güncellenmesi bir geliştirici için en önemli adımlardan biri. Migration süreçlerini de içeren, girintileri ve hiyerarşisi düzeltilmiş tam README.md içeriği aşağıdadır.

Bunu doğrudan projenin ana dizinine yapıştırabilirsin:

🥘 RecipeShare - Lezzet Paylaşım Platformu
RecipeShare, yemek tutkunlarının tariflerini paylaşabileceği, diğer kullanıcıların tariflerini inceleyip yorum yapabileceği modern bir platformdur. Proje, ASP.NET Core Web API ve MVC mimarisi kullanılarak "Loosely Coupled" (Gevşek Bağlı) prensibiyle geliştirilmektedir.

[!IMPORTANT]
🚧 Geliştirme Aşamasında: Bu proje şu anda aktif olarak geliştirilmektedir. Yeni özellikler eklenmeye ve mimari iyileştirmeler yapılmaya devam etmektedir.

🛠️ Kullanılan Teknolojiler
Backend: .NET 8 (C#)

Mimari: N-Tier Architecture (API + MVC UI)

Veritabanı & ORM: Entity Framework Core, SQL Server

Frontend: Bootstrap 5, JavaScript (AJAX / Fetch API)

Güvenlik: JWT (JSON Web Token) & Role-based Authorization

✅ Tamamlanan Özellikler
Veritabanı Modelleme: Tarif, Yorum ve Kullanıcı tabloları arasındaki ilişkiler kuruldu.

Web API: Tüm CRUD (Oluştur, Oku, Güncelle, Sil) işlemleri için endpoint'ler hazırlandı.

Yorum Sistemi: * AJAX (Fetch API) ile sayfa yenilenmeden yorum ekleme, silme ve düzenleme.

Rol tabanlı yetkilendirme (Admin siler, sahip düzenler).

Modern UI: Responsive tarif detay sayfası ve admin yönetim tabloları.

🏗️ Veritabanı ve Migration Süreçleri
Proje Entity Framework Core "Code-First" yaklaşımını kullanmaktadır. Veritabanını ayağa kaldırmak için aşağıdaki adımları izleyin:

Migration Oluşturma:

Bash
dotnet ef migrations add InitialCreate --project RecipeShare.Data --startup-project RecipeShare.DataApi
Veritabanını Güncelleme (Tabloları Oluşturma):

Bash
dotnet ef database update --project RecipeShare.Data --startup-project RecipeShare.DataApi
Not: Migration komutlarını çalıştırırken ana dizinde olduğunuzdan ve ConnectionStrings bilgilerinin appsettings.json içinde doğru tanımlandığından emin olun.

🚀 Planlanan Özellikler (Roadmap)
[ ] Görsel Yükleme: Tarifler için dinamik resim yükleme ve klasörleme sistemi.

[ ] Arama & Filtreleme: Kategori ve malzemeye göre gelişmiş arama.

[ ] Favoriler: Beğenilen tarifleri listeye ekleme özelliği.

[ ] Profil Sayfası: Kullanıcının kendi tariflerini yönetebileceği alan.

📦 Kurulum ve Çalıştırma
Depoyu klonlayın: git clone https://github.com/bariscoskunl/RecipeShare.git

appsettings.json içindeki SQL bağlantı dizesini güncelleyin.

Yukarıdaki Migration komutları ile veritabanını oluşturun.

Önce API projesini, ardından MVC projesini başlatın.

📬 İletişim
Herhangi bir sorunuz, öneriniz veya iş birliği fırsatınız varsa benimle iletişime geçebilirsiniz.

Email: bariscoskun441@gmail.com

GitHub: github.com/bariscoskunl

LinkedIn: linkedin.com/in/bariscoskun441