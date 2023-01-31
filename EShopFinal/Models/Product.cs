
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EShopFinal.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [DisplayName("Product Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DisplayName("Product Heading")]
        public string Heading { get; set; } = string.Empty;

        [Required]
        [DisplayName("Product Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

        [Required]
        [DisplayName("Product Price")]
        public float Price { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}

