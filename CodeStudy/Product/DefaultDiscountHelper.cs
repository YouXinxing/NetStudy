using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.Product
{
    //默认折扣计算器
    public class DefaultDiscountHelper : IDiscountHelper
    {
        public decimal DiscountSize { get; set; }

        public DefaultDiscountHelper(decimal discountParam)
        {
            DiscountSize = discountParam;
        }


        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (DiscountSize / 10m * totalParam));
        }
    }
}
