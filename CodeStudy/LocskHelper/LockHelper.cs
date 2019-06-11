using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeStudy
{
    public class LockHelper
    {
        public static object lock_A = new object();
        public static object lock_B = new object();
        public void DoSomething()
        {

            lock (lock_A)
            {
                Thread.Sleep(2000);
                Console.WriteLine("我是lock_A,我想要lock_A"  );
                lock (lock_A)
                {
                    Console.WriteLine("没出现这句话表示死锁了"  );
                }
            }
        }

         
        /// <summary>
        /// A等B B等A 互相等待 造成死锁
        /// </summary>
        public static void Main3()
        {
            LockHelper a = new LockHelper();
            Thread th = new Thread(new ThreadStart(a.DoSomething));
            th.Start();

            lock (lock_B)
            {

                Console.WriteLine("我是lock_B,我想要lock_A");
                lock (lock_A)
                {
                    Console.WriteLine("没出现这句话表示死锁了");
                }
            }

            Console.WriteLine("没出现这句话表示死锁了");
            Console.ReadKey();
        }


       

        

    }
}
