using HotelLandon.Models;
using HotelLandon.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelLandon.MvcRazor.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly IRepositoryBase<Room> repository;

        public IndexModel(IRepositoryBase<Room> repository)
        {
            this.repository = repository;
        }

        public IList<Room> Rooms { get;set; }

        public async Task OnGetAsync()
        {
            Rooms = await repository.GetAllAsync();
        }
    }
}
