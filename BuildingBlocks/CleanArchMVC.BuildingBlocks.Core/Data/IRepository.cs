using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.BuildingBlocks.Core.Data
{
    public interface IRepository<T> 
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }

    public interface IRepository : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }


}
