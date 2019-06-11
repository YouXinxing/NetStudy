using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeStudy.Threads
{
    public  class IAsyncResultThread2
    {
        delegate string MyDelegate(string name, int age);
        public static void Main2( )
        {
            MyDelegate myDelegate = new MyDelegate(GetString);
            IAsyncResult result = myDelegate.BeginInvoke("刘备", 22, null, null);

            Console.WriteLine("主线程继续工作!");

            //比上个例子，只是利用多了一个IsCompleted属性，来判断异步线程是否完成
            //while (!result.IsCompleted)
            //{
            //    Thread.Sleep(500);
            //    Console.WriteLine("异步线程还没完成，主线程干其他事!");
            //}

            //比上个例子，判断条件由IsCompleted属性换成了AsyncWaitHandle，仅此而已
            while (!result.AsyncWaitHandle.WaitOne(200))
            {
                Thread.Sleep(500);
                Console.WriteLine("异步线程还没完成，主线程干其他事!");
            }

            //是否完成了指定数量
            WaitHandle[] waitHandleList = new WaitHandle[] { result.AsyncWaitHandle };
            while (WaitHandle.WaitAny(waitHandleList, 200) > 0)
            {
                Console.WriteLine("异步线程完成数未大于0，主线程继续甘其他事!");
            }

            WaitHandle[] waitHandleList2 = new WaitHandle[] { result.AsyncWaitHandle };
            //是否全部异步线程完成
            while (!WaitHandle.WaitAll(waitHandleList2, 200))
            {
                Console.WriteLine("异步线程未全部完成，主线程继续干其他事!");
            }

            string data = myDelegate.EndInvoke(result);
            Console.WriteLine(data);

            Console.ReadKey();
        }

        static string GetString(string name, int age)
        {
            Thread.Sleep(2000);
            return string.Format("我是{0}，今年{1}岁!", name, age);
        }
    }
}
