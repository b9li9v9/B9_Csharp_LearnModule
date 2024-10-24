using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnDI.Source
{
    internal interface ICar
    {
        public string GetBrand();

        public IBattery GetBattery();
    }
}
