using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeStudy.Threads
{
      
    class Person
    {
        public Person(string name, int age) { this.Name = name; this.Age = age; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class ParameterizeThreadStartThread
    {
        static void Main(string[] args)
        {
            //整数作为参数
            for (int i = 0; i < 2; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Run));
                t.Start(i);
            }
            Console.WriteLine("主线程执行完毕！");

            //自定义类型作为参数
            Person p1 = new Person("关羽", 22);
            Person p2 = new Person("张飞", 21);
            Thread t1 = new Thread(new ParameterizedThreadStart(RunP));
            t1.Start(p1);
            Thread t2 = new Thread(new ParameterizedThreadStart(RunP));
            t2.Start(p2);

            Console.ReadKey();
        }

        public static void Run(object i)
        {
            Thread.Sleep(50);
            Console.WriteLine("线程传进来的参数是：" + i.ToString());
        }

        public static void RunP(object o)
        {
            Thread.Sleep(50);
            Person p = o as Person;
            Console.WriteLine(p.Name + p.Age);
        }
    }
}
