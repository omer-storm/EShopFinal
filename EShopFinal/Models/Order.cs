using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EShopFinal.Models
{
    public class Order
    {
        [Display(Name = "Order Id")]
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Required Field!")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Required Field!")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Required Field!")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Required Field!")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Required Field!")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Required Field!")]
        public string Status { get; set; } = string.Empty;

    }
}
