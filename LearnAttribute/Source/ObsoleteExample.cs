using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnAttribute.Source
{
    internal class ObsoleteExample
    {
        [Obsolete("Will be removed in next version.")]
        public  int ObsoleteExampleAdd(int a, int b)
        {
            return (a + b);
        }

    }
}
