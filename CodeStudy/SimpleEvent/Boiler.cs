using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.SimpleEvent
{
    // boiler 类
    public class Boiler
    {
        private int temp;
        private int pressure;
        public Boiler(int t, int p)
        {
            temp = t;
            pressure = p;
        }

        public int getTemp()
        {
            return temp;
        }
        public int getPressure()
        {
            return pressure;
        }
    }
}
