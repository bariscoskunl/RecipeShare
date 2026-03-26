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

            List<Role> roles = new()
            {
                 new Role { Id = 1, Name = "Admin" },
                 new Role { Id = 2, Name = "User" }
            };
            // 1. Kullanıcılar
            List<User> users = new()
            {
                 new User { Id = 1, Username = "bariscoskun", Email = "bariscoskun441@gmail.com", PasswordHash = "1234", RoleId = 1 },
                 new User { Id = 2, Username = "yazilimci_ali", Email = "ali@mail.com", PasswordHash = "abcd5678", RoleId = 2 },
                 new User { Id = 3, Username = "doga_chef", Email = "doga@mail.com", PasswordHash = "efgh5678", RoleId = 1 }
            };

            // 2. Tarifler
            List<Recipe> recipes = new()
            {
                 new Recipe { Id = 1, Title = "Sahanda Yumurta", Content = "Yumurtayı tavaya kırarak yapabilirsiniz.", CreatedDate = DateTime.Now, UserId = 1 },
                 new Recipe { Id = 2, Title = "Mercimek Çorbası", Content = "Mercimekleri haşlayıp blenderdan geçirin.", CreatedDate = DateTime.Now.AddDays(-1), UserId = 2 }
            };

            // 3. Yorumlar
            List<Comment> comments = new()
            {
                 new Comment { Id = 1, Text = "Harika bir tarif!", CreatedDate = DateTime.Now, UserId = 2, RecipeId = 1 },
                 new Comment { Id = 2, Text = "Çok lezzetli görünüyor.", CreatedDate = DateTime.Now, UserId = 1, RecipeId = 2 }
            };
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Recipe>().HasData(recipes);
            modelBuilder.Entity<Comment>().HasData(comments);
            modelBuilder.Entity<Role>().HasData(roles);

        }
    }
}
