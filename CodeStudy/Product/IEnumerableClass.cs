using CodeStudy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.Product
{
    public class IEnumerableClass
    {

        static IEnumerableClass()
        {
            // 创建并初始化ShoppingCart实例，注入IEnumerable<Product>
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                new Product {Name = "Kayak", Price = 275},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            }
            };
            // 创建并初始化一个普通的Product数组
            Product[] productArray = {
            new Product {Name = "Kayak", Price = 275M},
            new Product {Name = "Lifejacket", Price = 48.95M},
            new Product {Name = "Soccer ball", Price = 19.50M},
            new Product {Name = "Corner flag", Price = 34.95M}
        };

            // 取得商品总价钱：用接口的方式调用TotalPrices扩展方法。
            decimal cartTotal = products.TotalPrices();
            // 取得商品总价钱：用普通数组的方式调用TotalPrices扩展方法。
            decimal arrayTotal = productArray.TotalPrices();

            Console.WriteLine("Cart Total: {0:c}", cartTotal);
            Console.WriteLine("Array Total: {0:c}", arrayTotal);
            Console.ReadKey();
        }
    }


    /// <summary>
    /// 购物车类 （实现 IEnumerable<Product> 接口）
    /// </summary>
    public class ShoppingCart : IEnumerable<Product>
    {
        public List<Product> Products { get; set; }
        public IEnumerator<Product> GetEnumerator()
        {
            return Products.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// 定义一个静态类，用于实现扩展方法（注意：扩展方法必须定义在静态类中）
    /// </summary>
    public static class MyExtensionMethods2
    {
        /// <summary>
        /// 计算商品总价钱
        /// </summary>
        public static decimal TotalPrices(this IEnumerable<Product> productEnum)
        {
            decimal total = 0;
            foreach (Product prod in productEnum)
            {
                total += prod.Price;
            }
            return total;
        }
    }


}
