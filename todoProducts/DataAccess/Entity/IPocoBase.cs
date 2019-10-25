using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoProducts.DataAccess.Entity
{
    public interface IPocoBase
    {
        ObjectId _Id { get; set; }
    }
}