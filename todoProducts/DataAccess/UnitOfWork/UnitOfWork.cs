using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoProducts.DataAccess.Context;
using todoProducts.DataAccess.Entity;

namespace todoProducts.DataAccess.UnitOfWork
{
    public class UnitOfWork
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
        }
    }
}