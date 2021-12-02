using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VehicleDepot.Data;
using VehicleDepot.Models;

namespace VehicleDepot.Pages.Manufacturers
{
    public class IndexModel : PageModel
    {
        private readonly VehicleDepot.Data.VehicleDepotContext _context;

        public IndexModel(VehicleDepot.Data.VehicleDepotContext context)
        {
            _context = context;
        }

        public IList<Manufacturer> Manufacturer { get;set; }

        public async Task OnGetAsync()
        {
            Manufacturer = await _context.Manufacturer.ToListAsync();
        }
    }
}
