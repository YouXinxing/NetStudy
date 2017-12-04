using CodeStudy.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.Product
{
    public  interface IValueCalculator
    {
        decimal ValueProducts(params Product[] products);
    }

   
}
