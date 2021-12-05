using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VehicleDepot.Data;
using VehicleDepot.Models;

namespace VehicleDepot.Pages.Vehicles
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly VehicleDepot.Data.VehicleDepotContext _context;

        public DeleteModel(VehicleDepot.Data.VehicleDepotContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vehicle Vehicle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehicle = await _context.Vehicle.FirstOrDefaultAsync(m => m.ID == id);

            if (Vehicle == null)
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

            Vehicle = await _context.Vehicle.FindAsync(id);

            if (Vehicle != null)
            {
                _context.Vehicle.Remove(Vehicle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
