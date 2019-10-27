using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoProducts.BusinessLogic.Request;
using todoProducts.BusinessLogic.Response;

namespace todoProducts.BusinessLogic
{
    public interface IProductManager
    {
        Task List(ProductRequest request, ProductResponse response);
        Task GetById(ProductRequest request, ProductResponse response);
        Task Add(ProductRequest request, ProductResponse response);
        Task Update(ProductRequest request, ProductResponse response);
        Task Remove(ProductRequest request, ProductResponse response);
    }
}
