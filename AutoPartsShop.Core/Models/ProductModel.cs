using Shared.ValidationConstants;
using System.ComponentModel.DataAnnotations;
using AutoPartsShop.Infrastructure.Database.Models;


namespace AutoPartsShop.Core.Models
{
    public class ProductModel
    {

        public int Id { get; set; }


        [Required]
        [StringLength(ProductValidationConstants.NameMaxLength)]
        public string Name { get; set; } = null!;


        [StringLength(ProductValidationConstants.ProductNumberMaxLength)]
        public string ProductNumber { get; set; } = string.Empty;


        [Required]
        [Range(0.01, 100_000)]
        public decimal Price { get; set; }


        [StringLength(ProductValidationConstants.DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(ProductValidationConstants.ManufacturerMaxLength)]
        public string Manufacturer { get; set; } = string.Empty;

        [Required]
        public int StockQuantity { get; set; }

        public int SelectedCategoryId { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();



    }

}
