using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.Product
{
    /// <summary>
    /// 计算商品价格
    /// </summary>
    public class LinqValueCalculator : IValueCalculator
    {
        private IDiscountHelper discounter;

        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            discounter = discountParam;
        }

        public LinqValueCalculator()
        {

        }

        public decimal ValueProducts(params Product[] products)
        {
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
            //return products.Sum(p => p.Price);
        }

        //public decimal ApplyDiscount(params Product[] products)
        //{
        //    var sum = products.Sum(p => p.Price);
        //    return discounter.ApplyDiscount(sum);
        //}
    }
}
