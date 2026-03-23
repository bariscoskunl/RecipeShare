using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Data.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Comments> Comments { get; set; } = new HashSet<Comments>();
    }
    public class  RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        { 
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Title).IsRequired().HasMaxLength(200);
            builder.Property(r => r.Content).IsRequired();
            builder.Property(r => r.CreatedDate).IsRequired();
            builder.HasOne(r => r.User)
                .WithMany(u => u.Recipes)
                .HasForeignKey(r => r.UserId);


        }        
    }
}
