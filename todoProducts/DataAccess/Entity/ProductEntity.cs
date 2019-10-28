using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace todoProducts.DataAccess.Entity
{
    public class ProductEntity : IPocoBase, IPocoCreate, IPocoRemovable, IPocoUpdate
    {
        private ProductEntity()
        {
        }

        public ProductEntity(string name, decimal price)
        {
            Id = Guid.NewGuid().ToString();
            IsActive = true;
            Name = name;
            Price = price;

        }

        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}