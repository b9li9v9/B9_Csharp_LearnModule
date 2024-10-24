using LearnEFCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnEFCore
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 如果你使用的是命令行工具（如 dotnet ef），你需要使用 --startup-project 选项来指定包含 DbContext 配置的项目。
        /// dotnet ef migrations add ABCjk --project Infrastruct --startup-project WebApi
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            /// options 参数的提供者：AddDbContext 方法
            ///在 ASP.NET Core 中，
            ///当我们调用 services.AddDbContext<ApplicationDbContext>(options => ...) 
            ///这行代码时，实际上是在向服务容器中注册一个 ApplicationDbContext 类型的服务。
            ///这个方法内部会创建一个 DbContextOptionsBuilder 实例，
            ///并将其作为参数传递给我们提供的 lambda 表达式。

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                .AddTransient<ApplicationDbseeder>(); ;
            
            return services;
        }


    }
}
