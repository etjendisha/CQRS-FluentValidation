using Application.Interfaces;
using Application.Interfaces.GenericRepository;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.GenericRepository
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

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            context.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate) 
            => await context.Where(predicate).ToListAsync();


        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await context.SingleOrDefaultAsync(predicate);


        public async Task<IEnumerable<TEntity>> GetAllAsync() 
            => await context.ToListAsync();


        public async Task<TEntity> GetByIdAsync(TKey id) 
            => await context.FindAsync(id);


        public async Task<IEnumerable<TEntity>> GetPagedReponseAsync(int pageNumber, int pageSize) 
            => await context.Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .AsNoTracking()
                            .ToListAsync();


        public async Task<TEntity> RemoveAsync(TKey id)
        {
            var entity = await context.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Remove(entity);
            await db.SaveChangesAsync();

            return entity;
        }


        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            context.Attach(entity);
            SetModified(entity);

            await db.SaveChangesAsync();
            return entity;
        }


        public virtual void SetModified(TEntity entity) 
            => db.Entry(entity).State = EntityState.Modified;

        public async Task<TEntity> RemoveAsync(TEntity entity)
        {
            context.Remove(entity);

            await db.SaveChangesAsync();
            return entity;
        }
    }
}


