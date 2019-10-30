using todoProducts.BusinessLogic.Model;

namespace todoProducts.BusinessLogic.Response
{
    public class ProductResponse : BaseResponse
    {
        public ProductModel Product { get; set; }
    }
}