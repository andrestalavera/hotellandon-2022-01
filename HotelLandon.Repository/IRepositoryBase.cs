using HotelLandon.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelLandon.Repository
{
    public interface IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity, int id);
        Task<bool> DeleteAsync(int id);
    }
}
