using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeStudy.Threads
{
    class QueueUserWorkItemThread2
    {
        public static void Main2()
        {
            Person p = new Person(1, "刘备");
            //启动工作者线程
            ThreadPool.QueueUserWorkItem(new WaitCallback(RunWorkerThread), p);
            Console.ReadKey();
        }

        public static void RunWorkerThread(object obj)
        {
            Thread.Sleep(200);
            Console.WriteLine("线程池线程开始!");
            Person p = obj as Person;
            Console.WriteLine(p.Name);
        }
        public class Person
        {
            public Person(int id, string name) { Id = id; Name = name; }
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }

    
}
