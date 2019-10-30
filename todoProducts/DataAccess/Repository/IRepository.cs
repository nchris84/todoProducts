using System.Collections.Generic;
using System.Threading.Tasks;

namespace todoProducts.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> List();

        Task<T> GetById(string id);

        void Add(T obj);

        void Update(T obj);

        void Remove(T obj);
    }
}