﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.Product
{
    //折扣计算接口
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }

    

}
