using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.AttributeHelper
{
    public class ConsoleTask
    {
        static ConsoleTask()
        {
            //CheckReflection();
            //ExecuteRectangle();
            MainEvent();
        }


        public static void MainEvent()
        {
            EventTest e = new EventTest(); /* 实例化对象,第一次没有触发事件 */
            subscribEvent v = new subscribEvent(); /* 实例化对象 */
            e.ChangeNum += new EventTest.NumManipulationHandler(v.printf); /* 注册 */
            e.SetValue(7);
            e.SetValue(11);
        }



        public static void  CheckReflection()
        {
            System.Reflection.MemberInfo info = typeof(MyAttrClass);
            object[] attributes = info.GetCustomAttributes(true);
            for (int i = 0; i < attributes.Length; i++)
            {
                System.Console.WriteLine(attributes[i]);
            }
            Console.ReadKey();
        }


        public static void ExecuteRectangle()
        {
            Rectangle r = new Rectangle(4.5, 7.5);
            r.Display();
            Type type = typeof(Rectangle);
            // 遍历 Rectangle 类的特性
            foreach (Object attributes in type.GetCustomAttributes(false))
            {
                DeBugInfo dbi = (DeBugInfo)attributes;
                if (null != dbi)
                {
                    Console.WriteLine("Bug no: {0}", dbi.BugNo);
                    Console.WriteLine("Developer: {0}", dbi.Developer);
                    Console.WriteLine("Last Reviewed: {0}",
                         dbi.LastReview);
                    Console.WriteLine("Remarks: {0}", dbi.Message);
                }
            }

            // 遍历方法特性
            foreach (MethodInfo m in type.GetMethods())
            {
                foreach (Attribute a in m.GetCustomAttributes(true))
                {
                    DeBugInfo dbi = (DeBugInfo)a;
                    if (null != dbi)
                    {
                        Console.WriteLine("Bug no: {0}, for Method: {1}",
                              dbi.BugNo, m.Name);
                        Console.WriteLine("Developer: {0}", dbi.Developer);
                        Console.WriteLine("Last Reviewed: {0}",
                              dbi.LastReview);
                        Console.WriteLine("Remarks: {0}", dbi.Message);
                    }
                }
            }
            Console.ReadLine();
        }
    
    }
}
