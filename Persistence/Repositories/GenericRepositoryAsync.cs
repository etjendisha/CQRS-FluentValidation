using Application.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepositoryAsync<TEntity, TKey> : IGenericRepositoryAsync<TEntity, TKey> where TEntity : class
    {
        private readonly ReactivitiesContext db;
        protected DbSet<TEntity> context;


        public GenericRepositoryAsync(ReactivitiesContext dbContext)
        {
            db = dbContext;
            context = db.Set<TEntity>();
        }

 
        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await context.FindAsync(id);
        }


        public async Task<IReadOnlyList<TEntity>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await context
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await context.ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            context.Add(entity);
            db.ChangeTracker.TrackGraph(entity, e =>
            {
                e.Entry.State = EntityState.Added;
            });

            return context.Add(entity).Entity;
        }

        public async Task<IReadOnlyList<TEntity>> AddRange(IReadOnlyList<TEntity> entities)
        {
            foreach (var entity in entities)
            {

                context.Add(entity);
                db.ChangeTracker.TrackGraph(entity, e =>
                {
                    e.Entry.State = EntityState.Added;
                });
            }

            context.AddRange(entities);
            return entities;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRangeAsync(IReadOnlyList<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveRangeAsync(IReadOnlyList<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public async Task PatchUpdateAsync(TEntity entity, string[] fieldsToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}