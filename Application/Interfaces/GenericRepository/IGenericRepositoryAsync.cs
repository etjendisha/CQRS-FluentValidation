using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.GenericRepository
{
    public interface IGenericRepositoryAsync<TEntity, TKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetPagedReponseAsync(int pageNumber, int pageSize);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> RemoveAsync(TKey id);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
