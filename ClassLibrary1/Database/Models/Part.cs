using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Infrastructure.Database.Models
{
    public class Part
    {


        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string PartNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Manufacturer { get; set; } = string.Empty;


        [Required]
        [Range(0.01, 1000_000)]
        public decimal Price { get; set; }


        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;


        [Required]
        public int Stock { get; set; }


        public string? ImageFileName { get; set; }



        [ForeignKey(("Category"))]
        public int CategoryId { get; set; }
        public Category? Category { get; set; } 



        public ICollection<CarPart> CarParts = new List<CarPart>();


    }


}
