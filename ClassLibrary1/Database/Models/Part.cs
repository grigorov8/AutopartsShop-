using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



using Shared.ValidationConstants;

namespace AutoPartsShop.Infrastructure.Database.Models
{
    public class Part
    {


        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(PartsValidationConstants.NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(PartsValidationConstants.PartNumberMaxLength)]
        public string PartNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(PartsValidationConstants.ManufacturerMaxLength)]
        public string Manufacturer { get; set; } = string.Empty;


        [Required]
        [Range(0.01, 100_000)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(PartsValidationConstants.DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;


        [Required]
        public int Stock { get; set; }


        public string ImageFileName { get; set; } = string.Empty;


        [Range(0, 5)]
        public double AverageRating { get; set; } = 0;


        [ForeignKey(("Category"))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;



        public ICollection<CarPart> CarParts = new List<CarPart>();


    }


}
