using ConsoleApplication.OutAndIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.OutRefIn
{
    internal static class Ref
    {
        public static void ModifyNumber(ref int i)
        {
            i = i + 100;
        }

        public static void RefRun()
        {
            int i = 1;
            Console.WriteLine($"before {i}");
            Ref.ModifyNumber(ref i);
            Console.WriteLine($"afther {i}");
        }
    }
}

