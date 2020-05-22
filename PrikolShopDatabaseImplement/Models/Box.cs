using System.ComponentModel.DataAnnotations;

namespace PrikolShopDatabaseImplement.Models
{
    public class Box
    {
        public int Id { get; set; }
        public int GiftBoxId { get; set; }
        public int GiftId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Gift Gift { get; set; }
        public virtual GiftBox GiftBox { get; set; }
    }

}
