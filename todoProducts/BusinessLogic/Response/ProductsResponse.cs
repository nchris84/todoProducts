﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoProducts.BusinessLogic.Model;

namespace todoProducts.BusinessLogic.Response
{
    public class ProductsResponse: BaseResponse
    {
        public IEnumerable<ProductModel> Products { get; set; }
    }
}