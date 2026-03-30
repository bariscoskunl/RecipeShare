using Microsoft.Extensions.DependencyInjection;
using RecipeShare.Business.Services.Auth;
using RecipeShare.Business.Services.Comments;
using RecipeShare.Business.Services.Recipes;
using RecipeShare.Business.Services.Roles;
using RecipeShare.Business.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Business
{
    public static class BusinessExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITokenService, TokenService>();      
        }
    }
}
