using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieApi.Context;
using MovieApi.Entities;
using MovieApi.Repository.Interfaces;

namespace MovieApi.Repository
{
    public class GenericAsyncRepository<T> : IGenericAsyncRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _entity;

        public GenericAsyncRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _entity = _dbContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entity.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.State);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _entity.AsNoTracking().Where(x => x.State).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            entity.State = false;
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}