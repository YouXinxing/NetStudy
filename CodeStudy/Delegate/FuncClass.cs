using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy
{
    public  class FuncClass
    {
        public FuncClass()
        {
            Console.WriteLine(Test<int, int>(Fun, 100, 200));
            Console.ReadKey();
        }
        public static int Test<T1, T2>(Func<T1, T2, int> func, T1 a, T2 b)
        {
            return func(a, b);
        }
        private static int Fun(int a, int b)
        {
            return a + b;
        }
    }
}
