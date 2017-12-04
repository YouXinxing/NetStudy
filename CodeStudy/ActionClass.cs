using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy
{
    public class ActionClass
    {
        public ActionClass()
        {
            Test<string>(Action, "Hello World!");
            Test<int>(Action, 1000);

            Test<string>(Action2, "Hello World!");
            Test<int>(Action2, 1000);

            Test<string>(p => { Console.WriteLine("{0}", p); }, "Hello World");//使用Lambda表达式定义委托
            Console.ReadKey();
        }

        public static void Test<T>(Action<T> action, T p)
        {
            action(p);
        }
        private static void Action(string s)
        {
            Console.WriteLine(s);
        }
        private static void Action(int s)
        {
            Console.WriteLine(s);
        }

        private static void Action2(string s)
        {
            Console.WriteLine(s);
        }
        private static void Action2(int s)
        {
            Console.WriteLine(s);
        }
    }
}
