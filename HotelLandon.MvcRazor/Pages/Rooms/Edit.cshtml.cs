using HotelLandon.Models;
using HotelLandon.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLandon.MvcRazor.Pages.Rooms
{
    public class EditModel : PageModel
    {
        private readonly IRepositoryBase<Room> repository;

        public EditModel(IRepositoryBase<Room> repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || !id.HasValue)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await repository.UpdateAsync(Room, Room.Id);


            return RedirectToPage("./Rooms/Index");
        }
    }
}
