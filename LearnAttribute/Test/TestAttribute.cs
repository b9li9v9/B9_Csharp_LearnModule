using LearnAttribute.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnAttribute.Test
{
    public class TestAttribute
    {
        public async Task TestAttributeMain(bool io=false)
        {
            if(io)
            {
                var attributes = typeof(SampleClass).GetCustomAttributes(false);
                foreach (var attr in attributes)
                {
                    if (attr is MyCustomAttribute myAttr)
                    {
                        Console.WriteLine(myAttr.Description);
                    }
                }

                ObsoleteExample obsoleteExample = new();
                Console.WriteLine(obsoleteExample.ObsoleteExampleAdd(1,1));
            }
        }
    }
}
