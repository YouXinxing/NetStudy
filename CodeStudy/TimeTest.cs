using PandaHome.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy
{
    public class TimeTest
    {
        public TimeTest()
        {
            Init();
        }

        public void Init()
        {
            long time = Convert.ToDateTime("2017-02-27 01:00:00").ToUnixMillisecond() - Convert.ToDateTime("2017-02-27").ToUnixMillisecond();
            long time2 = Convert.ToDateTime("2017-02-27 00:30:00").ToUnixMillisecond() - Convert.ToDateTime("2017-02-27").ToUnixMillisecond();
            Console.WriteLine(string.Format("time = {0} time2 = {1}", time, time2));
            Console.ReadKey();

        }
    }

   
}
