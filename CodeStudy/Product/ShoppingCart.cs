using CodeStudy.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.Product
{
    public class ShoppingCart2
    {
        //IValueCalculator calculator;
        //IDiscountHelper discalculator;
        //Product[] products = null;

        //public ShoppingCart2()
        //{

        //}

        protected IValueCalculator calculator;
        protected Product[] products;
        

        //构造函数，参数为实现了IValueCalculator接口的类的实例
        public ShoppingCart2(IValueCalculator calcParam)
        {
            calculator = calcParam;
            products = new[]{
                new Product {Name = "西瓜", Category = "水果", Price = 2.3M},
                new Product {Name = "苹果", Category = "水果", Price = 4.9M},
                new Product {Name = "空心菜", Category = "蔬菜", Price = 2.2M},
                new Product {Name = "地瓜", Category = "蔬菜", Price = 1.9M}
            };
        }



        ////构造函数，参数为实现了IValueCalculator接口的类的实例
        //public ShoppingCart2(IValueCalculator calcParam,IDiscountHelper discalcParam)
        //{
        //    products = new Product[]  {
        //        new Product { Name = "西瓜", Category = "水果", Price = 2.3M },
        //        new Product { Name = "苹果", Category = "水果", Price = 4.9M },
        //        new Product { Name = "空心菜", Category = "蔬菜", Price = 2.2M },
        //        new Product { Name = "地瓜", Category = "蔬菜", Price = 1.9M },
        //    };
        //    calculator = calcParam;
        //    discalculator = discalcParam;
        //}




        //计算购物车内商品总价钱
        public virtual decimal CalculateStockValue()
        {
            //计算商品总价钱 
            decimal totalValue = calculator.ValueProducts(products);
            return totalValue;
        }

        //计算购物车内商品总价钱
        //public decimal CalculateStockValue()
        //{
        //    Product[] products = new Product[]  {
        //        new Product { Name = "西瓜", Category = "水果", Price = 2.3M },
        //        new Product { Name = "苹果", Category = "水果", Price = 4.9M },
        //        new Product { Name = "空心菜", Category = "蔬菜", Price = 2.2M },
        //        new Product { Name = "地瓜", Category = "蔬菜", Price = 1.9M },
        //    };

        //    //IValueCalculator calculator = new LinqValueCalculator();
        //    //计算商品总价钱 
        //    decimal totalValue = calculator.ValueProducts(products);
        //    return totalValue;
        //}

        ////计算商品折扣价钱 
        //public decimal GetDiscount()
        //{
            
        //    decimal totalValue = discalculator.ApplyDiscount(CalculateStockValue());
        //    return totalValue;
        //}

    }
}
