using Shared.ValidationConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Infrastructure.Database.Models
{

    public class Product
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
        [StringLength (ProductValidationConstants.ManufacturerMaxLength)]
        public string Manufacturer { get; set; } = string.Empty; 

        [Required]
        public int StockQuantity { get; set; } 


        public string Image {  get; set; } = string.Empty;


        [ForeignKey(("Category"))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

    }
}
