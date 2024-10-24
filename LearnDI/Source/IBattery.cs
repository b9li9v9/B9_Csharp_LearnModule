using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnDI.Source
{
    internal interface IBattery
    {
        public int ReadValue();
        public IBattery AddValue(int value);

    }
}
