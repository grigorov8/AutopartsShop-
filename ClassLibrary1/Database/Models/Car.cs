using Shared.ValidationConstants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace AutoPartsShop.Infrastructure.Database.Models
{
    public class Car
    {


        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(CarValidationConstants.MakeMaxLength)]
        public string Make { get; set; } = string.Empty;


        [Required]
        [StringLength(CarValidationConstants.ModelMaxLenght)]
        public string Model { get; set; } = string.Empty;


        [Required]
        [Range(CarValidationConstants.MinYear, CarValidationConstants.MaxYear)]
        public int Year { get; set; }


        [Required]
        [StringLength(CarValidationConstants.VinLenght, MinimumLength = CarValidationConstants.VinLenght)]
        public string Vin { get; set; } = string.Empty;


        [Required]
        [ForeignKey("Engine")]
        public int EngineId { get; set; }  
        public Engine? Engine { get; set; }


        public ICollection<CarPart> CarParts { get; set; } = new List<CarPart>();




    }


}
