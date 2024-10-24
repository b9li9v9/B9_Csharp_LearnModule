using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLearnEFCoreMigration
{
    public class Cat
    {
        public Cat(string name,int age)
        {
            this.name = name;
            this.age = age;
        }

        public string name { get; set; }
        public int age { get; set; }

        private string color { get; set; }

        public void miao()
        {
            Console.WriteLine("miao miao! ");
        }
    }

}
