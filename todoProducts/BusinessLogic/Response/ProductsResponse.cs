using System.Collections.Generic;
using todoProducts.BusinessLogic.Model;

namespace todoProducts.BusinessLogic.Response
{
    public class ProductsResponse : BaseResponse
    {
        public IEnumerable<ProductModel> Products { get; set; }
    }
}