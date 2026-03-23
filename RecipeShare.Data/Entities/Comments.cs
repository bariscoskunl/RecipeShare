using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Data.Entities
{
    public class Comments
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public User User { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }



    }
    public class  CommentsConfiguration : IEntityTypeConfiguration<Comments>
    {        public void Configure(EntityTypeBuilder<Comments> builder)
        { 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Text).IsRequired().HasMaxLength(500);

            builder.HasOne(c => c.User)
               .WithMany(c => c.Comments)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Recipe)
               .WithMany(r => r.Comments) 
               .HasForeignKey(c => c.RecipeId)
               .OnDelete(DeleteBehavior.Cascade);

        }
        
    }
}
