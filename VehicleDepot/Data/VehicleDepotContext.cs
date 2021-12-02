using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleDepot.Models;

namespace VehicleDepot.Data
{
    public class VehicleDepotContext : DbContext
    {
        public VehicleDepotContext (DbContextOptions<VehicleDepotContext> options)
            : base(options)
        {
        }

        public DbSet<VehicleDepot.Models.Vehicle> Vehicle { get; set; }

        public DbSet<VehicleDepot.Models.Category> Category { get; set; }

        public DbSet<VehicleDepot.Models.Manufacturer> Manufacturer { get; set; }
    }
}
