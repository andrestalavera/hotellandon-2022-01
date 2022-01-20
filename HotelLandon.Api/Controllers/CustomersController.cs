using HotelLandon.Models;
using HotelLandon.Repository;
using Microsoft.Extensions.Logging;

namespace HotelLandon.Api.Controllers
{
    public class CustomersController : GenericController<IRepositoryBase<Customer>, Customer>
    {
        public CustomersController(IRepositoryBase<Customer> repository,
            ILogger<GenericController<IRepositoryBase<Customer>, Customer>> logger)
            : base(repository, logger)
        {
        }
    }
}
