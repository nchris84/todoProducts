using System;
using System.Threading.Tasks;
using todoProducts.DataAccess.Entity;
using todoProducts.DataAccess.Repository;

namespace todoProducts.DataAccess.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        Task<bool> Commit();

        IRepository<T> Repository<T>() where T : class, IPocoBase;
    }
}