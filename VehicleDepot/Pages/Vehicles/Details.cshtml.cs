using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VehicleDepot.Data;
using VehicleDepot.Models;

namespace VehicleDepot.Pages.Vehicles
{
    public class DetailsModel : PageModel
    {
        private readonly VehicleDepot.Data.VehicleDepotContext _context;

        public DetailsModel(VehicleDepot.Data.VehicleDepotContext context)
        {
            _context = context;
        }

        public Vehicle Vehicle { get; set; }
        public String ImageString { get; set; }
        public String ManufacturerName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehicle = await _context.Vehicle.FirstOrDefaultAsync(m => m.ID == id);

            var mf = await _context.Manufacturer.FirstOrDefaultAsync(m => m.Id == Vehicle.ID);

            ImageString = mf.ImageString;
            ManufacturerName = mf.Name;

            if (Vehicle == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
