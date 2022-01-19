using HotelLandon.Data;
using HotelLandon.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelLandon.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        private HotelLandonContext context;

        public RepositoryBase() => context = new HotelLandonContext();

        public IEnumerable<TEntity> GetAll() => context.Set<TEntity>().ToList();

        public TEntity Get(int id) => context.Set<TEntity>().Find(id);

        public bool Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return context.SaveChanges() == 1;
        }

        public bool Update(TEntity entity, int id)
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
            return context.SaveChanges() == 1;
        }

        public bool Delete(int id)
        {
            TEntity entity = Get(id);

            if (entity is not null)
            {
                context.Remove(entity);
                return context.SaveChanges() == 1;
            }
            return false;
        }
    }
}
