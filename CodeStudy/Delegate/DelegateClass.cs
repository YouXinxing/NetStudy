using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy
{
    public class DelegateClass
    {
        public delegate int MethodDelegate(int x, int y);
        private static MethodDelegate method;

        static DelegateClass()
        {
            method = new MethodDelegate(Add);
            Console.WriteLine(method(10, 20));
            Console.ReadKey();
        }
        private static int Add(int x, int y)
        {
            return x + y;
        }
    }
}
