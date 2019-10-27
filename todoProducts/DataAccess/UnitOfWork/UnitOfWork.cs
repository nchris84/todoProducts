using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoProducts.DataAccess.Context;
using todoProducts.DataAccess.Entity;
using todoProducts.DataAccess.Repository;

namespace todoProducts.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit() => await _context.SaveChanges() > 0 ? true : false;

        public IRepository<T> Repository<T>() where T : class, IPocoBase
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
                return repositories[typeof(T)] as IRepository<T>;

            IRepository<T> repo = new Repository<T>(_context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}