using Microsoft.EntityFrameworkCore;
using RecipeShare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RecipeShare.Data
{
    internal class RecipeShareDbContext : DbContext
    {
        public RecipeShareDbContext(DbContextOptions<RecipeShareDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());
            modelBuilder.ApplyConfiguration(new CommentsConfiguration());
            // 1. Roller 
            List<Role> roles = new()
            {
                 new Role { Id = 1, Name = "Admin" },
                 new Role { Id = 2, Name = "User" }
            };
            // 2. Kullanıcılar
            List<User> users = new()
            {
                 new User { Id = 1, Username = "bariscoskun", Email = "bariscoskun441@gmail.com", PasswordHash = "1234", RoleId = 1 },
                 new User { Id = 2, Username = "yazilimci_ali", Email = "ali@mail.com", PasswordHash = "abcd5678", RoleId = 2 },
                 new User { Id = 3, Username = "doga_chef", Email = "doga@mail.com", PasswordHash = "efgh5678", RoleId = 1 },
                 new User { Id = 4, Username = "mutfak_robotu", Email = "robot@mail.com", PasswordHash = "1234", RoleId = 2 }
            };

            // 3. Tarifler
            List<Recipe> recipes = new()
            {
                 new Recipe { Id = 1, Title = "Sahanda Yumurta", Content = "Tereyağını sahanda eritip köpürmesini bekleyin. Yumurtaları sarılarını bozmadan kırın, üzerine bir tutam tuz ve pul biber ekleyerek beyazları tamamen pişene kadar orta ateşte tutun.", CreatedDate = DateTime.Now.AddDays(-5), UserId = 1, ImageUrl = "/images/default-recipe.jpg" },
                 new Recipe { Id = 2, Title = "Mercimek Çorbası", Content = "Soğan, havuç ve patatesi kavurduktan sonra yıkanmış kırmızı mercimeği ekleyin. Sıcak su ilavesiyle mercimekler yumuşayana kadar haşlayıp blenderdan geçirin. Üzerine kızgın tereyağlı sos dökün.", CreatedDate = DateTime.Now.AddDays(-4), UserId = 2, ImageUrl = "/images/default-recipe.jpg" },
                 new Recipe { Id = 3, Title = "İtalyan Usulü Pizza", Content = "İnce açılmış hamurun üzerine taze fesleğenli domates sosu ve bol mozarella peyniri yayın. Tercihen taş fırında veya 250 derece ısıtılmış fırında kenarları çıtırlaşana kadar yaklaşık 10 dakika pişirin.", CreatedDate = DateTime.Now.AddDays(-3), UserId = 3, ImageUrl = "/images/default-recipe.jpg" },
                 new Recipe { Id = 4, Title = "Ev Yapımı Burger", Content = "Dinlendirilmiş dana kıymadan hazırlanan kalın köfteleri döküm tavada mühürleyin. Karamelize soğan, cheddar peyniri ve özel burger sosu ile ısıtılmış brioche ekmeği arasında servis yapın.", CreatedDate = DateTime.Now.AddDays(-2), UserId = 1, ImageUrl = "/images/default-recipe.jpg" },
                 new Recipe { Id = 5, Title = "Zeytinyağlı Enginar", Content = "Garnitür karışımını (bezelye, havuç, patates) limonlu suda bekletilmiş enginarların ortasına yerleştirin. Bol sızma zeytinyağı, bir tutam şeker ve portakal suyu ekleyerek kısık ateşte yumuşayana kadar pişirin.", CreatedDate = DateTime.Now.AddDays(-1), UserId = 4, ImageUrl = "/images/default-recipe.jpg" }
            };

            // 4. Yorumlar
            List<Comment> comments = new()
            {
                 new Comment { Id = 1, Text = "Harika bir tarif, denedim çok güzel oldu!", CreatedDate = DateTime.Now.AddHours(-2), UserId = 2, RecipeId = 1 },
                 new Comment { Id = 2, Text = "Tuzu biraz az geldi ama kıvamı müthiş.", CreatedDate = DateTime.Now.AddHours(-1), UserId = 3, RecipeId = 1 },
                 new Comment { Id = 3, Text = "Çok lezzetli görünüyor, elinize sağlık.", CreatedDate = DateTime.Now, UserId = 1, RecipeId = 2 },
                 new Comment { Id = 4, Text = "Blenderdan geçirmeden önce süzmek daha iyi sonuç veriyor.", CreatedDate = DateTime.Now, UserId = 4, RecipeId = 2 }
            };
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Recipe>().HasData(recipes);
            modelBuilder.Entity<Comment>().HasData(comments);
            modelBuilder.Entity<Role>().HasData(roles);

        }
    }
}
