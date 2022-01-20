using HotelLandon.Models;
using HotelLandon.Repository;
using Microsoft.Extensions.Logging;

namespace HotelLandon.Api.Controllers
{
    public class RoomsController : GenericController<IRepositoryBase<Room>, Room>
    {
        public RoomsController(IRepositoryBase<Room> repository,
            ILogger<GenericController<IRepositoryBase<Room>, Room>> logger)
            : base(repository, logger)
        {
        }
    }
}
