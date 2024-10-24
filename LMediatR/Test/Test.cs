using LearnMediatR.Source;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace LearnMediatR.Test
{
    /// <summary>
    /// 程序集通过 .dll 或 .exe 文件形式存在，而命名空间仅仅是逻辑上的组织结构，不影响实际的编译单元。
    /// 一个类库，或者一个控制台、一个webapi，实际上都是编译成一个.dll或.exe
    /// </summary>
    public class TestMediatR
    {
        public async Task TestMediatRMain(bool io = false)
        {
            if (io) 
            { 
                var services = new ServiceCollection().AddMediatR(Assembly.GetExecutingAssembly());

                Console.WriteLine($"Assembly: {Assembly.GetExecutingAssembly()}");

                var serviceProvider = services.BuildServiceProvider();

                services.PrintServiceDescriptors();

                var sender = serviceProvider.GetRequiredService<ISender>();


                await TestMediatRRun(sender, "hi world.");
            }
        }

        private async Task TestMediatRRun(ISender sender, string name)
        {
            HelloRequest helloRequest = new() { Name = "abc" };

            // 发送请求并获取结果
            var result = await sender.Send(helloRequest);

            // 输出结果
            Console.WriteLine($"Request Handler result:{result._name}");

            Console.ReadKey();

        }
    }
}
