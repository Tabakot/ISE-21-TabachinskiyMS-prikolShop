using System.Collections.Generic;
using System.ComponentModel;

namespace PrikolShopBusinessLogic.ViewModels
{
    public class GiftBoxViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название подарочного набора")]
        public string GiftBoxName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> Boxes { get; set; }
    }
}
