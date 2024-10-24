using LearnConfig.Source;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LearnConfig.Test
{
    public class TestConfig
    {
        public async Task TestConfigMain(bool io = false)
        {
            if (io)
            {
                var configService = new ConfigService();
                configService.PrintAppSettings();

                Console.WriteLine("--------------------------");

                var confBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                
                IConfiguration _confBuilder = confBuilder.Build();
                
                var CatMapConfig = _confBuilder.GetSection(nameof(ConfigMapCat));

                var serviceCollection = new ServiceCollection();
                serviceCollection.Configure<ConfigMapCat>(CatMapConfig);

                var serviceProvider = serviceCollection.BuildServiceProvider();

                var configMapCat1 = serviceProvider.GetRequiredService<IOptions<ConfigMapCat>>().Value;
                Console.WriteLine($"configMapCat1.name: {configMapCat1.name}");

                var configMapCat2 = serviceProvider.GetService<IOptions<ConfigMapCat>>().Value;
                Console.WriteLine($"configMapCat2.name: {configMapCat2.name}");

                Console.ReadKey();
            }
        }
    }
}
