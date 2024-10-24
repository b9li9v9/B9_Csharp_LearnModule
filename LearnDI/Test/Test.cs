using LearnDI.Source;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnDI.Test
{
    public class TestDI
    {
        public async Task TestDIMain(bool io = false)
        {
            if (io)
            {

                var serviceCollection = new ServiceCollection()
               .AddTransient<ICar, Car>()
               .AddTransient<IBattery, Battery>();
               
                var serviceProvider = serviceCollection.BuildServiceProvider();

                // 从服务容器中获取服务
                var car = serviceProvider.GetService<ICar>();
                var batteryValue = car.GetBattery().AddValue(299).ReadValue();
                Console.WriteLine($"batteryValue = {batteryValue}");
                Console.ReadKey();
            }
        }
    }
}
