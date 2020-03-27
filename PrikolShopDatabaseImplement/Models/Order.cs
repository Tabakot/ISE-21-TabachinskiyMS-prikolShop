using PrikolShopBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrikolShopDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int GiftBoxId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual GiftBox GiftBox { get; set; }
    }
}
