using LearnActionAndFunc.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnActionAndFunc.Test
{
    public  class TestActionAndFunc
    {
        public async Task TestActionAndFuncMain(bool io = false)
        {
            if (io)
            {
                LearnAction.action("hi, is me");
                LearnAction.func(10);
                LearnAction.MyOneOptions(options => { Console.WriteLine(options); });
                LearnAction.MyTwoOptions((optionsA, optionsB) => { Console.WriteLine($"{optionsA}, {optionsB}"); });
                LearnAction.MyClassOptions(options => 
                    {
                        options.ClassName = "CustomClassName";
                        options.ClassAge = "CustomClassAge";
                        Console.WriteLine($"{options.ClassName}, {options.ClassAge}"); });

            }
        }
    }
}
