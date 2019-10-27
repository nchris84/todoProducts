using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoProducts.BusinessLogic.Model;

namespace todoProducts.BusinessLogic.Request
{
    public class ProductRequest: BaseRequest
    {
        public string Id { get; set; }
        public ProductModel Product { get; set; }
    }
}
