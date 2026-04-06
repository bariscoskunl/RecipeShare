# 🥘 RecipeShare - Lezzet Paylaşım Platformu

RecipeShare, yemek tutkunlarının tariflerini paylaşabileceği, diğer kullanıcıların tariflerini inceleyip yorum yapabileceği modern bir platformdur.  

Proje, ASP.NET Core Web API ve MVC mimarisi kullanılarak **"Loosely Coupled" (Gevşek Bağlı)** prensibiyle geliştirilmektedir.

---

> [!IMPORTANT]
> 🚧 **Geliştirme Aşamasında:**  
> Bu proje şu anda aktif olarak geliştirilmektedir. Yeni özellikler eklenmeye ve mimari iyileştirmeler yapılmaya devam etmektedir.

---

## 🛠️ Kullanılan Teknolojiler

| Alan        | Teknoloji |
|------------|----------|
| Backend    | .NET 8 (C#) |
| Mimari     | N-Tier Architecture (API + MVC UI) |
| Veritabanı & ORM | SQL Server, Entity Framework Core |
| Frontend   | Bootstrap 5, JavaScript (AJAX / Fetch API) |
| Güvenlik   | JWT (JSON Web Token) & Role-based Authorization |

---

## ✅ Tamamlanan Özellikler

- **Veritabanı Tasarımı:** Tarif, yorum ve kullanıcı tabloları arasındaki ilişkiler kuruldu.  
- **Web API:** Tüm CRUD işlemleri için sağlam endpoint'ler hazırlandı.  
- **Dinamik Yorum Sistemi:**
  - AJAX (Fetch API) ile sayfa yenilenmeden yorum ekleme, silme ve düzenleme  
- **Yetkilendirme:**
  - Admin tüm yorumları yönetebilir  
  - Kullanıcılar sadece kendi yorumlarını düzenleyebilir  
- **Responsive UI:** Tüm cihazlarla uyumlu arayüz  

---

## 🏗️ Veritabanı ve Migration Süreçleri

Proje, EF Core **Code-First** yaklaşımını kullanmaktadır.

### Migration oluşturma:
```bash
dotnet ef migrations add InitialCreate --project RecipeShare.Data --startup-project RecipeShare.DataApi
```

### Veritabanını güncelleme:
```bash
dotnet ef database update --project RecipeShare.Data --startup-project RecipeShare.DataApi
```

> ⚠️ Not:  
> - Komutları ana dizinde çalıştırdığınızdan emin olun  
> - `appsettings.json` içindeki connection string doğru olmalı  

---

## 🚀 Planlanan Özellikler (Roadmap)

- [ ] Görsel Yükleme (Tarif resimleri)
- [ ] Arama & Filtreleme (Kategori + malzeme)
- [ ] Favoriler sistemi
- [ ] Kullanıcı profil sayfası

---

## 📦 Kurulum ve Çalıştırma

### 1. Depoyu klonlayın
```bash
git clone https://github.com/bariscoskunl/RecipeShare.git
```

### 2. Veritabanı ayarını yapın
`appsettings.json` içindeki connection string'i güncelleyin

### 3. Migration çalıştırın
(Yukarıdaki komutlar)

### 4. Projeyi başlatın
- Önce API
- Sonra MVC

---

## 📬 İletişim

Herhangi bir sorunuz, öneriniz veya iş birliği fırsatınız varsa:

- 📧 Email: bariscoskun441@gmail.com  
- 💻 GitHub: https://github.com/bariscoskunl  
- 🔗 LinkedIn: https://linkedin.com/in/bariscoskun441  

---

## 👨‍💻 Geliştirici

Bu proje **Barış Coşkun** tarafından tutkuyla geliştirilmektedir.
