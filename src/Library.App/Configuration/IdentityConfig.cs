using Library.App.Data;
using Library.App.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.App.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection IdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            /*
             * Organizando a aplicação
             */
            services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseSqlServer(
                                configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUserCustom>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            return services;
        }
    }
}