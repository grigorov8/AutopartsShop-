using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Core.Models
{
    public class PartSearchByCarModel
    {


        public string Make {  get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public int Year { get; set; } 

        public decimal Displacement { get; set; } 



    }

}
