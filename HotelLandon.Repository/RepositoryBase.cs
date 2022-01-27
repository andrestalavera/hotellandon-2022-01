using HotelLandon.Data;
using HotelLandon.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace HotelLandon.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        private HotelLandonContext context;

        public RepositoryBase(HotelLandonContext context) => this.context = context;

        public Task<List<TEntity>> GetAllAsync() => context.Set<TEntity>().ToListAsync();

        public Task<List<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicat)
        {
            // On prépare la requête
            IQueryable<TEntity> query = context.Set<TEntity>().AsQueryable();
            if (predicat != null)
            {
                query = query.Where(predicat);
            }
            // On exécute la requête
            return query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id) => await context.Set<TEntity>().FindAsync(id);

        public async Task<bool> AddAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return await context.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateAsync(TEntity entity, int id)
        {
            var local = context.Set<TEntity>()
            .Local
            .FirstOrDefault(entry => entry.Id.Equals(id));

            // check if local is not null 
            if (local != null)
            {
                // detach
                context.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            context.Entry(entity).State = EntityState.Modified;

            // save 
            return await context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            TEntity entity = await GetAsync(id);

            if (entity is not null)
            {
                context.Remove(entity);
                return await context.SaveChangesAsync() == 1;
            }
            return false;
        }
    }
}
