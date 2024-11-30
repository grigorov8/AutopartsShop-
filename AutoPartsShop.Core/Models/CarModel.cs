using System.ComponentModel.DataAnnotations;
using Shared.ValidationConstants;


namespace AutoPartsShop.Core.Models
{
    public class CarModel
    {

        public int Id { get; set; }
        
        [Required]
        [StringLength(CarValidationConstants.MakeMaxLength, MinimumLength = 2)]
        public string Make { get; set; } = string.Empty;

        [Required]
        [StringLength(CarValidationConstants.ModelMaxLenght, MinimumLength = 1)]
        public string Model { get; set; } = string.Empty;

        [Required]
        [Range(CarValidationConstants.MinYear, CarValidationConstants.MaxYear)]
        public int Year { get; set; }

        [Required]
        [Range(CarValidationConstants.EngineCapacityMin, CarValidationConstants.EngineCapacityMax)]
        public decimal EngineCapacity { get; set; }

        public string Image { get; set; } = string.Empty;


        [Required]
        [StringLength(CarValidationConstants.VinLenght, MinimumLength = 17)]
        public string Vin { get; set; } = string.Empty;

        public List<PartModel> Parts { get; set; } = new List<PartModel>();

    }
}
