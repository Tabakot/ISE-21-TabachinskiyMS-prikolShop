using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrikolShopDatabaseImplement.Models
{
    public class Gift
    {
        public int Id { get; set; }
        [Required]
        public string GiftName { get; set; }
        [ForeignKey("GiftId")]
        public virtual List<Box> Boxes { get; set; }
    }
}