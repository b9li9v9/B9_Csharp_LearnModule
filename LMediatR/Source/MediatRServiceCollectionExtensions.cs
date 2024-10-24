using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMediatR.Source
{
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// MediatR.IRequestHandler`2[[LearnMediatR.Source.HelloRequest, ConsoleTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[LearnMediatR.Source.User, ConsoleTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]] - Transient 
        /// 这是个泛型MediatR.IRequestHandler<LearnMediatR.Source.HelloRequest,LearnMediatR.Source.User>
        /// </summary>
        /// <param name="services"></param>
        public static void PrintServiceDescriptors(this IServiceCollection services)
        {
            foreach (var descriptor in services)
            {
                Console.WriteLine($"{descriptor.ServiceType.FullName} - {descriptor.Lifetime}");
            }
            Console.ReadKey();

        }
    }
}
