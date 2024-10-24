using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.OutAndIn
{
    internal static class In
    {
        static void DisplayPoint(in Point p)
        {
            // 这里不能修改 p 的值
            Console.WriteLine($"Point: ({p.X}, {p.Y})");
        }

        public static void InRun()
        {
            Point point = new Point { X = 10, Y = 20 };
            DisplayPoint(in point);
        }

    }

    struct Point
    {
        public int X;
        public int Y;
    }
}
