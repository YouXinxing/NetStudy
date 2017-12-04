using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy
{
    static class randomclass
    {
        public static bool NextBool(this Random random)
        {
            return random.NextDouble() > 0.5;
        }

        static randomclass()
        {
            //调用扩展方法
            Random rd = new Random();
            bool bl = rd.NextBool();

            Console.WriteLine(bl.ToString());
            Console.ReadKey();
        }

    }
}
