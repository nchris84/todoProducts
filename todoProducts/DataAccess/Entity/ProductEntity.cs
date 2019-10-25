using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoProducts.DataAccess.Entity
{
    public class ProductEntity : IPocoBase, IPocoCreate, IPocoRemovable, IPocoUpdate
    {
        private ProductEntity()
        {
        }

        public ProductEntity(string name, decimal price)
        {
            Id = new Guid();
            IsActive = true;
            Name = name;
            Price = price;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ObjectId _Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}