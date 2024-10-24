using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnDI.Source
{
    internal class Battery : IBattery
    {
        private int BatteryValue { get; set; } = 0;
        public IBattery AddValue(int value)
        {
            BatteryValue += value;
            return this;
        }

        public int ReadValue()
        {
            return BatteryValue;
        }
    }
}
