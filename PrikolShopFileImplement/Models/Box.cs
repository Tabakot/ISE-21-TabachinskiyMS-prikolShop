using System;
using System.Collections.Generic;
using System.Text;

namespace PrikolShopFileImplement.Models
{
    public class Box
    {
        public int Id { get; set; }
        public int GiftBoxId { get; set; }
        public int GiftId { get; set; }
        public int Count { get; set; }
    }
}
