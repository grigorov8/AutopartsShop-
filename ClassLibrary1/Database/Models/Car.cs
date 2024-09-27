using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Infrastructure.Database.Models
{
    public class Car
    {


        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(100)]
        public string Make { get; set; } = string.Empty;


        [Required]
        [StringLength(100)]
        public string Model { get; set; } = string.Empty;


        [Required]
        public int Year { get; set; }


        [Required]
        [StringLength(17, MinimumLength = 17)]
        public string Vin { get; set; } = string.Empty;


        [Required]
        [ForeignKey("Engine")]
        public int EngineId { get; set; }  
        public Engine? Engine { get; set; }


        public ICollection<CarPart> CarParts { get; set; } = new List<CarPart>();




    }


}
