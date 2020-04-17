using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrikolShopDatabaseImplement.Models
{
    public class GiftBox
    {
        public int Id { get; set; }
        [Required]
        public string GiftBoxName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("GiftBoxId")]
        public virtual List<Box> Boxes { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
