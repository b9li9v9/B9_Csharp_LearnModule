using LearnEFCore.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace WebAPIApplication
{
    public static class ServiceCollectionExtensions
    {
        internal static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
        {
            using var servicesScope = app.ApplicationServices.CreateScope(); //释放所有该域内实例
            var seeders = servicesScope.ServiceProvider.GetServices<ApplicationDbseeder>();
            foreach (var seeder in seeders)
            {
                seeder.SeedDatabaseAsync().GetAwaiter().GetResult();
            }
            return app;
        }

        // 注入
        internal static IServiceCollection AddIdentitySettings(this IServiceCollection services)
        {
            services
                .AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
