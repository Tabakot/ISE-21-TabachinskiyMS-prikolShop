using System;
using System.Collections.Generic;
using System.Text;

namespace PrikolShopBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int GiftBoxId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
