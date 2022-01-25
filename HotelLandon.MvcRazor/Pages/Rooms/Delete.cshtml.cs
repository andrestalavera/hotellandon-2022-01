using HotelLandon.Models;
using HotelLandon.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelLandon.MvcRazor.Pages.Rooms
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositoryBase<Room> repository;

        public DeleteModel(IRepositoryBase<Room> repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room = await repository.GetAsync(id.Value);

            if (Room == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await repository.DeleteAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
