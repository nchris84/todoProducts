using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todoProducts.BusinessLogic.Model;
using todoProducts.BusinessLogic.Request;
using todoProducts.BusinessLogic.Response;
using todoProducts.BusinessLogic.ServiceManager.Product;

namespace todoProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceManager _service;

        public ProductController(IProductServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ProductsResponse>> List()
        {
            var request = new ProductRequest();
            return await _service.List(request);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProductById(string id)
        {
            var request = new ProductRequest();
            request.Id = id;
            return await _service.GetById(request);
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponse>> AddProduct([FromBody] ProductModel model)
        {
            var request = new ProductRequest();
            request.Product = model;
            return await _service.Add(request);
        }

        [HttpPut]
        public async Task<ActionResult<ProductResponse>> UpdateProduct([FromBody] ProductModel model)
        {
            var request = new ProductRequest();
            request.Product = model;
            return await _service.Update(request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> RemoveProduct(string id)
        {
            var request = new ProductRequest();
            request.Id = id;
            var response = await _service.Remove(request);
            return new
            {
                succes = response.Success.ToString(),
                errors = response.Errors
            };
        }
    }
}