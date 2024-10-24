using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.OutRefIn
{
    internal class ClassStaticMetho
    {
        public static void sayhi() => Console.WriteLine($"{typeof(ClassStaticMetho).Name} hi.");
    }
}
