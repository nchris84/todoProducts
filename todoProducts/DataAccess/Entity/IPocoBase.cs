using MongoDB.Bson;

namespace todoProducts.DataAccess.Entity
{
    public interface IPocoBase
    {
        ObjectId _Id { get; set; }
    }
}