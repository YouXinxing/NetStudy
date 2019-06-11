using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy
{
    class DelegateClass2
    {
        public DelegateClass2()
        {
            Apple apple = new Apple();
            Foxconn foxconn = new Foxconn();
            //创建委托实例
            //apple.AssembleIphone = new Apple.AssembleIphoneHandler(foxconn.AssembleIphone);

            //创建委托实例
            apple.AssembleIphone = new Apple.AssembleIphoneHandler(foxconn.AssembleIphone);
            //apple.AssembleIphone += new Apple.AssembleIphoneHandler(foxconn.PackIphone);
            apple.AssembleIphone = (Apple.AssembleIphoneHandler)System.Delegate.Combine(apple.AssembleIphone, new Apple.AssembleIphoneHandler(foxconn.PackIphone));
            apple.AssembleIphone += new Apple.AssembleIphoneHandler(foxconn.ShipIphone);

            apple.DesignIphone();

            //显示调用委托来进行异常处理或者返回值的保存。
            foreach (Apple.AssembleIphoneHandler method in apple.AssembleIphone.GetInvocationList())
            {
                try
                {
                    method();
                }
                catch
                {
                    Console.WriteLine("an exception happened");
                }
            }

            try
            {
                apple.AssembleIphone();
            }
            catch
            {
                Console.WriteLine("an exception happened");
            }



            //委托实例的调用
            //apple.AssembleIphone();
            //通过Invoke进行显示调用
            apple.AssembleIphone.Invoke();
            Console.Read();
        }
    }

    //1.声明一个委托类型
    //2.找到一个跟委托类型具有相同签名的方法（可以是实例方法，也可以是静态方法）
    //3.通过相同签名的方法来创建一个委托实例
    //4.通过委托实例的调用完成对方法的调用

    class Apple
    {
        //声明委托类型
        public delegate void AssembleIphoneHandler();

        public AssembleIphoneHandler AssembleIphone;
        public void DesignIphone()
        {
            Console.WriteLine("Design Iphone By Apple");
        }
    }

    class Foxconn
    {
        //与委托类型签名相同的方法
        public void AssembleIphone()
        {
            Console.WriteLine("Assemble Iphone By Foxconn");
        }
        public void PackIphone()
        {
            throw new NotImplementedException();
            //Console.WriteLine("Pack Ipnone By Foxconn");
        }
        public void ShipIphone()
        {
            Console.WriteLine("Ship Iphone By Foxconn");
        }
    }
}
