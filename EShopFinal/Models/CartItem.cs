using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EShopFinal.Models
{
    public class CartItem
    {
        [Display(Name = "Cart Item Id")]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Quantity Purchase")]
        public int Quantity { get; set; }

        [Display(Name = "Order ID")]
        [Required(ErrorMessage = "Required Field!")]
        public int OrderId { get; set; }
        public Order Order { get; set; }


        [Display(Name = "Product ID")]
        [Required(ErrorMessage = "Required Field!")]
        public int ProductId { get; set; }
        public Product Product { get; set; }


    }
}
