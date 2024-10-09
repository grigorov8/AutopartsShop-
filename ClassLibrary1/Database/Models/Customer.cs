using System.ComponentModel.DataAnnotations;
using Shared.ValidationConstants;


namespace AutoPartsShop.Infrastructure.Database.Models
{
    public class Customer
    {


        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(CustomerValidationConstants.NameMaxLength)]
        public string Name { get; set; } = string.Empty;


        [Required]
        [EmailAddress]
        [StringLength(CustomerValidationConstants.EmailMaxLength)]
        public string Email { get; set; } = string.Empty;


        [Required]
        [StringLength(CustomerValidationConstants.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = string.Empty;


        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;




    }
}
