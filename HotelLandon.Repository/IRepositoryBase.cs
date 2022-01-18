using HotelLandon.Models;
using System.Collections.Generic;

namespace HotelLandon.Repository
{
    public interface IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        bool Add(TEntity entity);
        bool Update(TEntity entity, int id);
        bool Delete(int id);
    }
}
