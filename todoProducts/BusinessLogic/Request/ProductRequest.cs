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
        public Guid ResultParserGuid { get; set; }

        public ProductRequest()
        {
            Product = new ProductModel();
        }

        public override void Validate()
        {
            if (!string.IsNullOrWhiteSpace(Product.Name) && Product.Name.Length > 100)
            {
                Errors.Add("Invalid name", "Name greater than 100 charts");
            }
            if (!string.IsNullOrWhiteSpace(Product.Id))
            {
                try
                {
                    Guid newGuid = new Guid(Product.Id);
                } catch (Exception ex)
                {
                    Errors.Add("Invalid Id", $"Id is incorrect, details: {ex.Message}");
                }
            };
        }
    }
}
