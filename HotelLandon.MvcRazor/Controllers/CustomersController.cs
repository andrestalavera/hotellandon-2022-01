using Microsoft.Extensions.Logging;
using HotelLandon.Repository;
using HotelLandon.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HotelLandon.MvcRazor.Controllers
{
    public class CustomersController : GenericController<IRepositoryBase<Customer>, Customer>
    {
        public CustomersController(IRepositoryBase<Customer> repository,
            ILogger<GenericController<IRepositoryBase<Customer>, Customer>> logger)
            : base(repository, logger)
        {
        }

        public override Task<ActionResult<Customer>> Create([Bind(new[] {
            nameof(Customer.Id),
            nameof(Customer.FirstName),
            nameof(Customer.LastName),
            nameof(Customer.BirthDate) })] Customer entity) => base.Create(entity);

        public override Task<IActionResult> Edit([Bind(new[] {
            nameof(Customer.Id),
            nameof(Customer.FirstName),
            nameof(Customer.LastName),
            nameof(Customer.BirthDate) })] Customer entity, int id) => base.Edit(entity, id);
    }
}