using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeStudy.Threads
{
    public  class IAsyncResultThread3
    {
        delegate string MyDelegate(string name, int age);
        public static void Main2( )
        {
            MyDelegate myDelegate = new MyDelegate(GetString);
            IAsyncResult result1 = myDelegate.BeginInvoke("刘备", 23, new AsyncCallback(Completed), null);

            Console.WriteLine("主线程继续工作!");

            
             

            Console.ReadKey();
        }

        static string GetString(string name, int age)
        {
            Thread.Sleep(2000);
            return string.Format("我是{0}，今年{1}岁!", name, age);
        }

        //供异步线程完成回调的方法
        static void Completed(IAsyncResult result)
        {
            //获取委托对象，调用EndInvoke方法获取运行结果
            AsyncResult _result = (AsyncResult)result;
            MyDelegate myDelegaate = (MyDelegate)_result.AsyncDelegate;
            //获得参数
            string data = myDelegaate.EndInvoke(_result);
            Console.WriteLine(data);
            //异步线程执行完毕
            Console.WriteLine("异步线程完成咯！");
            Console.WriteLine("回调函数也是由" + Thread.CurrentThread.Name + "调用的！");
        }
    }
}
