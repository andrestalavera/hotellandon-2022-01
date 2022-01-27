using HotelLandon.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelLandon.Repository
{
    public interface IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        Task<List<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicat);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity, int id);
        Task<bool> DeleteAsync(int id);
    }
}
