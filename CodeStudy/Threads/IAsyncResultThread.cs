using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeStudy.Threads
{
    public  class IAsyncResultThread
    {
        //除了最后两个参数，前面的都是你可定义的
        delegate string MyDelegate(string name, int age);
        public static void Main2()
        {
            //建立委托
            MyDelegate myDelegate = new MyDelegate(GetString);
            //异步调用委托，除最后两个参数外，前面的参数都可以传进去
            IAsyncResult result = myDelegate.BeginInvoke("刘备", 22, null, null);　　//IAsynResult还能轮询判断，功能不弱

            Console.WriteLine("主线程继续工作!");

            //调用EndInvoke(IAsyncResult)获取运行结果，一旦调用了EndInvoke，即使结果还没来得及返回，主线程也阻塞等待了
            //注意获取返回值的方式
            string data = myDelegate.EndInvoke(result);
            Console.WriteLine(data);

            Console.ReadKey();
        }

        static string GetString(string name, int age)
        {
            Console.WriteLine("我是不是线程池线程" + Thread.CurrentThread.IsThreadPoolThread);
            Thread.Sleep(2000*20);
            age = age + 10;
            return string.Format("我是{0}，今年{1}岁!", name, age);
        }
    }
}
