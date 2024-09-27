using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Core.Models
{
    public class PartModel
    {

        public int Id { get; set; }

        
     
        public string PartNumber { get; set; } = string.Empty;

        
        public string Name { get; set; } = string.Empty;

        
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public string? ImageFileName { get; set; } 




    }
}

