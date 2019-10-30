using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using todoProducts.BusinessLogic.Model;
using todoProducts.BusinessLogic.Request;
using todoProducts.BusinessLogic.Response;
using todoProducts.DataAccess.Entity;
using todoProducts.DataAccess.UnitOfWork;

namespace todoProducts.BusinessLogic
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task List(ProductRequest request, ProductsResponse response)
        {
            var productList = await _uow.Repository<ProductEntity>().List();
            response.Products = _mapper.Map<IEnumerable<ProductModel>>(productList);
        }

        public async Task GetById(ProductRequest request, ProductResponse response)
        {
            var dbProduct = await _uow.Repository<ProductEntity>().GetById(request.Id);
            response.Product = _mapper.Map<ProductModel>(dbProduct);
        }

        public async Task Add(ProductRequest request, ProductResponse response)
        {
            var product = new ProductEntity(request.Product.Name, request.Product.Price);
            _uow.Repository<ProductEntity>().Add(product);
            await _uow.Commit();
            var dbProduct = await _uow.Repository<ProductEntity>().GetById(product.Id);
            response.Product = _mapper.Map<ProductModel>(dbProduct);
        }

        public async Task Update(ProductRequest request, ProductResponse response)
        {
            var product = _mapper.Map<ProductEntity>(request.Product);
            var dbProduct = await _uow.Repository<ProductEntity>().GetById(product.Id);
            product.CreatedDate = dbProduct.CreatedDate;
            _uow.Repository<ProductEntity>().Update(product);
            await _uow.Commit();
            response.Product = _mapper.Map<ProductModel>(product);
        }

        public async Task Remove(ProductRequest request, ProductResponse response)
        {
            var product = await _uow.Repository<ProductEntity>().GetById(request.Id);
            _uow.Repository<ProductEntity>().Remove(product);
            await _uow.Commit();
        }
    }
}