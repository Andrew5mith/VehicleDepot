using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleDepot.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Mileage { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string Engine { get; set; } = string.Empty;

        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Features { get; set; } = string.Empty;
        public string ImageString { get; set; } = string.Empty;
        public string VinNumber { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public int ManufacturerID { get; set; }

    }
}
