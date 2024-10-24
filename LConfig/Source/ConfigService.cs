using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnConfig.Source
{
    public class ConfigService
    {
        private readonly IConfiguration _configuration;

        public ConfigService()
        {
            // 设置配置源
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = configurationBuilder.Build();
        }

        public void PrintAppSettings()
        {
            var appName = _configuration["AppSettings:AppName"];
            var version = _configuration["AppSettings:Version"];
            var Name = _configuration["MySettings:name"];
            var age = _configuration["MySettings:age"];
            var sex = _configuration["MySettings:sex:man"];


            Console.WriteLine($"App Name: {appName}");
            Console.WriteLine($"Version: {version}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Sex: {sex}");
        }
    }
}
