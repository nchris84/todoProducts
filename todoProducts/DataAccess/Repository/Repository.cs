using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoProducts.DataAccess.Context;
using todoProducts.DataAccess.Entity;

namespace todoProducts.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IPocoBase
    {
        protected readonly IMongoContext _context;
        protected readonly IMongoCollection<T> DbSet;

        public Repository(IMongoContext context)
        {
            _context = context;
            DbSet = _context.GetCollection<T>(typeof(T).Name);
        }

        public async Task<IEnumerable<T>> List()
        {
            var list = await DbSet.FindAsync(Builders<T>.Filter.Eq("IsActive", true));
            return list.ToList();
        }

        public async Task<T> GetById(Guid id)
        {
            var item = await DbSet.FindAsync(Builders<T>.Filter.Eq("id", id));
            return item.SingleOrDefault();
        }

        public void Add(T obj)
        {
            if (obj is IPocoCreate)
            {
                var poco = obj as IPocoCreate; //? po co?
                poco.CreatedDate = DateTime.Now;
            }
            _context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        public void Update(T obj)
        {
            if (obj is IPocoUpdate)
            {
                var poco = obj as IPocoUpdate;
                poco.UpdateDate = DateTime.Now;
            }
            _context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", obj._Id), obj));
        }

        public void Remove(T obj)
        {
            if (obj is IPocoRemovable)
            {
                var poco = obj as IPocoRemovable;
                poco.UpdateDate = DateTime.Now;
                poco.IsActive = false;
                _context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", obj._Id), obj));
            }
            else
            {
                _context.AddCommand(() => DbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", obj._Id)));
            }
        }

        //? po co
        //public void Dispose()
        //{
        //    _context?.Dispose();
        //}
    }
}