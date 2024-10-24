using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnActionAndFunc.Source
{
    internal static class LearnAction
    {
        public static Action<string> action = (str) => Console.WriteLine(str);
        public static Func<int, int> func = (i) => { var num = i + 1; Console.WriteLine(num); return num; };
        public static void MyOneOptions(Action<string> options)
        {
            string key = "abcKEY";
            options(key);
        }

        public static void MyTwoOptions(Action<string,string> options)
        {
            string keyA = "A KEY";
            string keyB = "B KEY";

            options(keyA,keyB);
        }

        public static void MyClassOptions(Action<MyClass> options)
        {
            MyClass myclass = new();
            options(myclass);
        }
    }
}
