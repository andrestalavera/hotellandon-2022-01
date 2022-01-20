using HotelLandon.Models;
using HotelLandon.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HotelLandon.Api.Controllers
{
    public class CustomersController : GenericController<IRepositoryBase<Customer>, Customer>
    {
        public CustomersController(IRepositoryBase<Customer> repository,
            ILogger<GenericController<IRepositoryBase<Customer>, Customer>> logger)
            : base(repository, logger)
        {
        }

        [HttpPost("[action]")]
        public async Task AddData()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 500; i++)
            {    
                await this.repository.AddAsync(new Customer
                {
                    FirstName = "A",
                    LastName = "B",
                    BirthDate = default
                });
            }
            logger.LogInformation("Add data: {ms}ms", sw.ElapsedMilliseconds);
        }
    }
}
