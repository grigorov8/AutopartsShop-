using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Infrastructure.Database.Models
{
    public class CarPart
    {


        [Key]
        public int Id { get; set; }


        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;


        [ForeignKey("Part")]
        public int PartId { get; set; }
        public Part Part { get; set; } = null!;



    }


}
