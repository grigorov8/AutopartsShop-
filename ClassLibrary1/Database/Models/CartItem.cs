using System.ComponentModel.DataAnnotations.Schema;



namespace AutoPartsShop.Infrastructure.Database.Models
{
    public class CartItem
    {

        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;

        public int Quantity { get; set; } = 1;


        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }


        [ForeignKey("Part")]
        public int? PartId { get; set; }
        public Part? Part { get; set; }

    }


}

