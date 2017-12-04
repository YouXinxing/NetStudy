using CodeStudy.DependencyInjection;
using CodeStudy.DependencyLocate;
using CodeStudy.Json;
using CodeStudy.Product;
using CodeStudy.Tasks;
using CodeStudy.Unity;
using NamespaceRef;
using Ninject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //DelegateClass model = new DelegateClass();

            //IEnumerableClass model = new IEnumerableClass();

            //Console.WriteLine("*********Fun with IEnumberable/IEnumerator************\n");
            //Garage carLot = new Garage();

            ////交出集合中的每一Car对象吗  
            //foreach (Car c in carLot)
            //{
            //    Console.WriteLine("{0} is going {1} MPH", c.CarName, c.CurrentSpeed);
            //}

            //Console.WriteLine("GetEnumerator被定义为公开的，对象用户可以与IEnumerator类型交互，下面的结果与上面是一致的");
            ////手动与IEnumerator协作  
            //IEnumerator i = carLot.GetEnumerator();
            //while (i.MoveNext())
            //{
            //    Car myCar = (Car)i.Current;
            //    Console.WriteLine("{0} is going {1} MPH", myCar.CarName, myCar.CurrentSpeed);
            //}
            //Console.ReadLine();


            //var item = new DelegateClass2();
            //var item = new ActionClass();
            //var item = new FuncClass();

            //var item = new PredicateClass();


            //var item = new LambdaClass();

            //我们所需要的是，在一个类内部，不通过创建对象的实例而能够获得某个实现了公开接口的对象的引用。这种“需要”，就称为DI（依赖注入，Dependency Injection），和所谓的IoC（控制反转，Inversion of Control ）是一个意思。

            //IValueCalculator calculator = new LinqValueCalculator();
            //var item = new ShoppingCart2(calculator);
            //Console.Write(item.CalculateStockValue());
            //Console.ReadLine();

            //var item = new AssemblyClass();

            //Country cy;
            //string assemblyName = @"NamespaceRef";
            //string strongClassName = @"NamespaceRef.China";
            //// 注意：这里类名必须为强类名
            //// assemblyName可以通过工程的AssemblyInfo.cs中找到
            //cy = (Country)Assembly.Load(assemblyName).CreateInstance(strongClassName);
            //Console.WriteLine(cy.name);
            //Console.ReadKey();

            //var item = new DependencyInjectionMain();
            //Console.ReadKey();

            //var item = new DependencyLocateMain();


            //var item = new NinjectClass();
            //var item = new JsonMain();
            //var item = new TimeTest();
            //var item = new urlTest();
            //var item = new CmdConsole();


            TimeClass s = new TimeClass();
            Console.Read();





        }
    }
}
