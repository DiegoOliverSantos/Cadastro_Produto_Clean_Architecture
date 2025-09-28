using CleanArchMVC.BuildingBlocks.Core.Data;
using CleanArchMVC.BuildingBlocks.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.BuildingBlocks.Infra.Data
{
    public class Repository<T> : IRepository<T> where T: Entity
    {


        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DbContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }


        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual Task<T> GetByIdAsync(Guid id)
        {
            return _dbSet.FirstOrDefaultAsync(i => i.ID == id);
        }

        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);

        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
