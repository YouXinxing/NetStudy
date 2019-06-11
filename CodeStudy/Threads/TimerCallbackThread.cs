using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.Threads
{
    public  class TimerCallbackThread
    {
        public static void Main2()
        {
            System.Threading.Timer clock = new System.Threading.Timer(ShowTime,null, 0, 1000);

            Console.ReadKey();
        }

        public static void ShowTime(object userData)
        {
            Console.WriteLine(DateTime.Now.ToString());
        }
    }
}
