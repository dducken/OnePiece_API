using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Core.Application.Common.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null);

        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, bool>> filter = null);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Patch(TEntity entity);

        void Delete(TEntity entity);
    }
}