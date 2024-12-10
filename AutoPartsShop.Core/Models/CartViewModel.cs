using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Core.Models
{
    public class CartViewModel
    {

       

        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
        public List<PartModel> Parts { get; set; } = new List<PartModel>();
        public decimal TotalPrice { get; set; }
    }

}
