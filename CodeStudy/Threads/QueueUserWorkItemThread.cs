using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeStudy.Threads
{
    public class QueueUserWorkItemThread
    {
        public static void Main3()
        {
            //工作者线程最大数目，I/O线程的最大数目
            ThreadPool.SetMaxThreads(1000, 1000);
            //启动工作者线程
            ThreadPool.QueueUserWorkItem(new WaitCallback(RunWorkerThread));
            Console.WriteLine("主线程");
            Console.ReadKey();
        }

        static void RunWorkerThread(object state)
        {
            Console.WriteLine("RunWorkerThread开始工作");
            Console.WriteLine("工作者线程启动成功!");
        }
    }
}
