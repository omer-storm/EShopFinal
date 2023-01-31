﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EShopFinal.Models
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Banner URL")]
        public string Url { get; set; } = string.Empty;

        [Required]
        [DisplayName("Banner Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DisplayName("Banner Heading")]
        public string Heading { get; set; } = string.Empty;

        [Required]
        [DisplayName("Banner Discription")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; } 

        [Required]
        public DateTime CreateDate { get; set; }
    }
}
