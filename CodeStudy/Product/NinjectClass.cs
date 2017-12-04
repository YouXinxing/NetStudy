using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.Product
{
    public class NinjectClass
    {
        IKernel ninjectKernel = new StandardKernel();
        public NinjectClass()
        {
            //ZhiDingZhiBangDing();
            

            PaiShengBangDing();

        }


        public void PaiShengBangDing()
        {
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            ninjectKernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>()
                .WithPropertyValue("DiscountSize", 5M);
            //派生类绑定
            ninjectKernel.Bind<ShoppingCart2>().To<LimitShoppingCart>()
                .WithPropertyValue("ItemLimit", 3M);
            

            ShoppingCart2 cart = ninjectKernel.Get<ShoppingCart2>();
            Console.WriteLine("Total: {0:c}", cart.CalculateStockValue());
            Console.ReadKey();
        }

        public void ZhiWoBangDing()
        {
            ninjectKernel.Bind<ShoppingCart>().ToSelf();
            ShoppingCart2 cart = ninjectKernel.Get<ShoppingCart2>();
        }

        public void ZhiDingZhiBangDing()
        {
            IKernel ninjectKernel = new StandardKernel();

            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();

            //如果要给多个属性赋值，则可以在Bind和To方式后添加多个WithPropertyValue(< 属性名 >,< 属性值 >)方法。
            //ninjectKernel.Bind<IDiscountHelper>()
            //    .To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 5M);

            ninjectKernel.Bind<IDiscountHelper>()
                .To<DefaultDiscountHelper>().WithConstructorArgument("discountParam", 5M);

            IValueCalculator calcImpl = ninjectKernel.Get<IValueCalculator>();
            ShoppingCart2 cart = new ShoppingCart2(calcImpl);
            Console.WriteLine("Total: {0:c}", cart.CalculateStockValue());
            Console.ReadKey();
        }

        public void FirstInit()
        {
            // 创建Ninject内核实例
            IKernel ninjectKernel = new StandardKernel();
            //绑定接口到实现了该接口的类
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();

            // 获得实现接口的对象实例
            IValueCalculator calcImpl = ninjectKernel.Get<IValueCalculator>();
            //// 创建ShoppingCart实例并注入依赖
            ShoppingCart2 cart = new ShoppingCart2(calcImpl);
            //// 计算商品总价钱并输出结果
            Console.WriteLine("Total: {0:c}", cart.CalculateStockValue());
        }

        public void YiBanZhiDing()
        {
            // 创建Ninject内核实例
            IKernel ninjectKernel = new StandardKernel();
            IValueCalculator calcImpl2 = new LinqValueCalculator();
            ShoppingCart2 cart2 = new ShoppingCart2(calcImpl2);
            Console.WriteLine("Total: {0:c}", cart2.CalculateStockValue());


            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            ninjectKernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>();

            IValueCalculator calcImpl3 = ninjectKernel.Get<IValueCalculator>();
            ShoppingCart2 cart3 = new ShoppingCart2(calcImpl3);
            Console.WriteLine("Total: {0:c}", cart3.CalculateStockValue());
            //Console.WriteLine("Total: {0:c}", cart3.GetDiscount());
            //Console.WriteLine() ;
        }
    }
}
