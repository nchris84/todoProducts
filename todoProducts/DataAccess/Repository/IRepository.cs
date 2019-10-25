using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoProducts.DataAccess.Repository
{
    internal interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> List();

        Task<T> GetById(Guid id);

        void Add(T obj);

        void Update(T obj);

        void Remove(T obj);
    }
}