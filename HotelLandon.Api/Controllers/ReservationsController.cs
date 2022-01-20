using HotelLandon.Models;
using HotelLandon.Repository;
using Microsoft.Extensions.Logging;

namespace HotelLandon.Api.Controllers
{
    public class ReservationsController : GenericController<IRepositoryBase<Reservation>, Reservation>
    {
        public ReservationsController(IRepositoryBase<Reservation> repository,
            ILogger<GenericController<IRepositoryBase<Reservation>, Reservation>> logger)
            : base(repository, logger)
        {
        }
    }
}
