using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.Product
{
    public class LimitShoppingCart : ShoppingCart2
    {
        public decimal ItemLimit { get; set; }
        public LimitShoppingCart(IValueCalculator calcParam)
            : base(calcParam)
        {
        }

        public override decimal CalculateStockValue()
        {
            //过滤价格超过了上限的商品
            var filteredProducts = products.Where(e => e.Price < ItemLimit);

            return calculator.ValueProducts(filteredProducts.ToArray());
        }

      
    }
}
