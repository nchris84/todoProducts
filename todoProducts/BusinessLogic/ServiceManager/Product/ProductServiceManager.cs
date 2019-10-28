using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using todoProducts.BusinessLogic.Request;
using todoProducts.BusinessLogic.Response;
using todoProducts.BusinessLogic.ServiceManager;
using todoProducts.BusinessLogic.ServiceManager.Product;
using todoProducts.DataAccess.Context;
using todoProducts.Extension;
using todoProducts.Logger;

namespace todoProducts.BusinessLogic.ServiceManager.Product
{
    public class ProductServiceManager: BaseService, IProductServiceManager
    {
        private readonly IProductManager _manager;

        public ProductServiceManager(IProductManager manager, ILoggerManager logger, IMongoContext context) : base(logger, context)
        {
            _manager = manager;
        }

        public async Task<ProductsResponse> List(ProductRequest request)
        {
            var response = new ProductsResponse();
            var methodInfo = nameof(List).MethodInfo(MethodBase.GetCurrentMethod());
            await RunCodeAsync(methodInfo, request, response, async (uow) =>
            {
                await _manager.List(request, response);
            });
            return response;
        }

        public async Task<ProductResponse> GetById(ProductRequest request)
        {
            var response = new ProductResponse();
            var methodInfo = nameof(GetById).MethodInfo(MethodBase.GetCurrentMethod());
            await RunCodeAsync(methodInfo, request, response, async (uow) =>
            {
                await _manager.GetById(request, response);
            });
            return response;
        }
        
        public async Task<ProductResponse> Add(ProductRequest request)
        {
            var response = new ProductResponse();
            var methodInfo = nameof(Add).MethodInfo(MethodBase.GetCurrentMethod());
            await RunCodeAsync(methodInfo, request, response, async (uow) =>
            {
                await _manager.Add(request, response);
            });
            return response;
        }

        public async Task<ProductResponse> Update(ProductRequest request)
        {
            var response = new ProductResponse();
            var methodInfo = nameof(Update).MethodInfo(MethodBase.GetCurrentMethod());
            await RunCodeAsync(methodInfo, request, response, async (uow) =>
            {
                await _manager.Update(request, response);
            });
            return response;
        }

        public async Task<ProductResponse> Remove(ProductRequest request)
        {
            var response = new ProductResponse();
            var methodInfo = nameof(Remove).MethodInfo(MethodBase.GetCurrentMethod());
            await RunCodeAsync(methodInfo, request, response, async (uow) =>
            {
                await _manager.Remove(request, response);
            });
            return response;
        }
    }
}
