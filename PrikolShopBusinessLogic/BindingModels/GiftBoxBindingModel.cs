using System.Collections.Generic;

namespace PrikolShopBusinessLogic.BindingModels
{
    public class GiftBoxBindingModel
    {
        public int? Id { get; set; }
        public string GiftBoxName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> Boxes { get; set; }

    }
}