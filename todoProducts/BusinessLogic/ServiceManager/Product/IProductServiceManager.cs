using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoProducts.BusinessLogic.Request;
using todoProducts.BusinessLogic.Response;

namespace todoProducts.BusinessLogic.ServiceManager.Product
{
    public interface IProductServiceManager
    {
        Task<ProductsResponse> List(ProductRequest request);
        Task<ProductResponse> GetById(ProductRequest request);
        Task<ProductResponse> Add(ProductRequest request);
        Task<ProductResponse> Update(ProductRequest request);
        Task<ProductResponse> Remove(ProductRequest request);
    }
}
