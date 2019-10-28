using MongoDB.Bson;
using System;

namespace todoProducts.DataAccess.Entity
{
    public interface IPocoBase
    {
        string Id { get; set; }
    }
}