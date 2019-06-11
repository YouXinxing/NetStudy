using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeStudy
{
    public class LocSelfkHelper
    { 
        public static void DoSomething(string lockname)
        {
            /// 线程同key 多线程工作中 会锁定
            string keyname = "2dsfasdfsdfad";
            lock (keyname)
            {
                Console.WriteLine(string.Format("{0}获得资源,休眠1000s", lockname));
                Thread.Sleep(10000000);
                Console.WriteLine(string.Format("{0}休眠结束", lockname));
                lock (lockname)
                {
                    Console.WriteLine("没出现这句话表示死锁了" + lockname);
                }
            }
        }

         
        /// <summary>
        /// A等B B等A 互相等待 造成死锁
        /// </summary>
        public static void Main3()
        { 
            var tasks = new List<Task>();
            var t1 = Task.Factory.StartNew(() =>
            {

                LocSelfkHelper.DoSomething("TASKA");
            });
            tasks.Add(t1);

            var t2 = Task.Factory.StartNew(() =>
            {
                LocSelfkHelper.DoSomething("TASKB");
            });
            tasks.Add(t2);

            var t3 = Task.Factory.StartNew(() =>
            { 
                LocSelfkHelper.DoSomething("TASKC");
            });
            tasks.Add(t3);

            Task.WaitAll(tasks.ToArray());



            Console.WriteLine("没出现这句话表示死锁了!!!");
            Console.ReadKey();
        }


       

        

    }
}
