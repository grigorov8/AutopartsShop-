
using Shared.Enums;
using System.ComponentModel.DataAnnotations;


namespace AutoPartsShop.Infrastructure.Database.Models
{
    public class Engine
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public EngineType Type { get; set; }

        [Required]  
        public decimal Displacement { get; set; }

        [Required]
        public int HorsePower { get; set; }


        [Required]
        [StringLength(50)]
        public string FuelType { get; set; } = string.Empty;  

        public ICollection<Car> Cars { get; set; } = new List<Car>();



    }
}
