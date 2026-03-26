using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecipeShare.Data.Repositories.Comments;
using RecipeShare.Data.Repositories.Recipes;
using RecipeShare.Data.Repositories.Roles;
using RecipeShare.Data.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Data
{
    public static class DataExtensions
    {
        public static void AddData(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DbContext, RecipeShareDbContext>(options =>
            {
                options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly("RecipeShare.Data"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
        }     
    }
}
