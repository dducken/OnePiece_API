using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (filter is not null)
                query = query.Where(filter);

            if (includeProperties is not null)
                query = includeProperties
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, property) => current.Include(property));

            return query;
        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, bool>>? filter = null,
            string? includeProperties = null)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (filter is not null)
                query = query.Where(filter);

            if (includeProperties is not null)
                query = includeProperties
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, property) => current.Include(property));

            return await query
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (filter is not null)
                query = query.Where(filter);

            return await query
                .FirstOrDefaultAsync(predicate);
        }

        public void Add(TEntity entity) => _dbContext.Set<TEntity>().Add(entity);

        public void Update(TEntity entity) => _dbContext.Entry(entity).State = EntityState.Modified;

        public void Patch(TEntity entity) => _dbContext.Attach(entity);

        public void Delete(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);
    }
}