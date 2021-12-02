using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleDepot.Data;
using VehicleDepot.Models;

namespace VehicleDepot.Pages.Vehicles
{
    public class IndexModel : PageModel
    {
        private readonly VehicleDepot.Data.VehicleDepotContext _context;

        public IndexModel(VehicleDepot.Data.VehicleDepotContext context)
        {
            _context = context;
        }

        public IList<Vehicle> Vehicle { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Makes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string VehicleMake { get; set; }
        public SelectList Models { get; set; }
        [BindProperty(SupportsGet = true)]
        public string VehicleModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 6;
        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Vehicle?.Count ?? 0, PageSize));

        public async Task OnGetAsync()
        {
            var vehicles = from m in _context.Vehicle
                           select m;

            // Use LINQ to get list of makes.
            IQueryable<string> makeQuery = from m in _context.Vehicle
                                           orderby m.Make
                                           select m.Make;

            // Use LINQ to get list of models.
            IQueryable<string> modelQuery = from m in _context.Vehicle
                                            orderby m.Model
                                            select m.Model;

            if (!string.IsNullOrEmpty(SearchString))
            {
                vehicles = vehicles.Where(s => s.Model.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(VehicleMake))
            {
                vehicles = vehicles.Where(s => s.Make.Contains(VehicleMake));
            }

            if (!string.IsNullOrEmpty(VehicleModel))
            {
                vehicles = vehicles.Where(s => s.Model.Contains(VehicleModel));
            }

            Models = new SelectList(await modelQuery.Distinct().ToListAsync());
            Makes = new SelectList(await makeQuery.Distinct().ToListAsync());

            Vehicle = await vehicles.ToListAsync();
        }
    }
}
