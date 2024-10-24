using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnDI.Source
{

    internal class Car : ICar
    {
        private string brand { get; set; }
        private IBattery battery { get; set; }

        public Car(IBattery battery)
        {
            this.battery = battery;
        }


        public string GetBrand()
        {
            return brand;
        }

        public IBattery GetBattery()
        {
            return battery;
        }

    }
}
