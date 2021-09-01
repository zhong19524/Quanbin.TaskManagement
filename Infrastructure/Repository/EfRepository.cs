using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly TaskManagementDbContext _dbContext;

        public EfRepository(TaskManagementDbContext taskManagementDbContext)
        {
            _dbContext = taskManagementDbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
             _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual Task<T> GetByIdAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            var data = await _dbContext.Set<T>().ToListAsync();
            return data;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        
    }
}
