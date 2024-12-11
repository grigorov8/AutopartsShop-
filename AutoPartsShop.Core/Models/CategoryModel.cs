using Shared.ValidationConstants;
using System.ComponentModel.DataAnnotations;

namespace AutoPartsShop.Core.Models
{

    public class CategoryModel
    {

        public int Id { get; set; }

       
        [StringLength(CategoryValidationConstants.NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        


    }

}
