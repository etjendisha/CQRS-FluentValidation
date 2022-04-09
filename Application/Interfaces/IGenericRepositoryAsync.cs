using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGenericRepositoryAsync<TEntity, TKey> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(TKey id);

        Task<IReadOnlyList<TEntity>> GetAllAsync();

        Task<IReadOnlyList<TEntity>> GetPagedReponseAsync(int pageNumber, int pageSize);

        Task<TEntity> AddAsync(TEntity entity);

        Task<IReadOnlyList<TEntity>> AddRange(IReadOnlyList<TEntity> entities);

        Task UpdateAsync(TEntity entity);

        Task UpdateRangeAsync(IReadOnlyList<TEntity> entities);

        /// <summary>
        /// If the entity to remove has Status field set its value to deleted. Else remove the entity from the database
        /// </summary>
        /// <param name="id">Id of element to delete</param>
        Task RemoveAsync(TKey id);

        /// <summary>
        /// If the entity to remove has Status field set its value to deleted. Else remove the entity from the database
        /// </summary>
        /// <param name="id">Element to delete</param>
        Task RemoveAsync(TEntity entity);

        /// <summary>
        /// Remove a renge of elements
        /// </summary>
        /// <param name="id">Elements to remove</param>
        Task RemoveRangeAsync(IReadOnlyList<TEntity> entities);

        Task PatchUpdateAsync(TEntity entity, string[] fieldsToUpdate);
    }
}
