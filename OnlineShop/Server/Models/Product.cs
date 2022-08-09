using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Server.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Desc { get; set; }
        [RegularExpression(@"^\w+\.(png|jpg)$")]
        public string? Img { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Price Can't Exceed 1000$")]
        public decimal Price { get; set; }
        public int Qty { get; set; }
        [ForeignKey("ProdCategory")]
        public int CategoryId { get; set; }

        public ProductCategory ProdCategory { get; set; }
    }
}
