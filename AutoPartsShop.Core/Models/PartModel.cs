using System.ComponentModel.DataAnnotations;
using Shared.ValidationConstants;


namespace AutoPartsShop.Core.Models
{
    public class PartModel
    {

        public int Id { get; set; }


        [StringLength(PartsValidationConstants.NameMaxLength, MinimumLength = 1,
             ErrorMessage = "Името трябва да бъде между {2} и {1} символа.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(PartsValidationConstants.PartNumberMaxLength, MinimumLength = 1,
             ErrorMessage = "Номерът на частта трябва да бъде между {2} и {1} символа.")]
        public string PartNumber { get; set; } = string.Empty;

        [Required]
      
        public decimal Price { get; set; }

        [StringLength(500, ErrorMessage = "Описание не може да бъде по-дълго от {1} символа.")]
        public string Description { get; set; } = string.Empty;


        [StringLength(PartsValidationConstants.ManufacturerMaxLength, ErrorMessage = "Производителят не може да бъде по-дълъг от {1} символа.")]
        public string Manufacturer { get; set; } = string.Empty;


        public string? ImageFileName { get; set; } 




    }
}

