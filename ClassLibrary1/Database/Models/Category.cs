using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.ValidationConstants;

namespace AutoPartsShop.Infrastructure.Database.Models
{
    public class Category
    {


        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryValidationConstants.NameMaxLength)]
        public string Name { get; set; } = string.Empty;


        public ICollection<Part> Parts { get; set; } = new List<Part>();

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }



}
