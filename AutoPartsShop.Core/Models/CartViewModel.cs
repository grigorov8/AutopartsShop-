using System.ComponentModel.DataAnnotations;


namespace AutoPartsShop.Core.Models
{
    public class CartViewModel
    {

       
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();

        public List<PartModel> Parts { get; set; } = new List<PartModel>();


        public decimal TotalPrice { get; set; }

    }

}
