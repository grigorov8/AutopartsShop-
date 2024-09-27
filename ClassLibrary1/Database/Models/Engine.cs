using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Infrastructure.Database.Models
{
    public class Engine
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } = string.Empty;

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
