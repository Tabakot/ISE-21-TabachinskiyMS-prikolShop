using PrikolShopBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrikolShopBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }
        public string GiftBoxName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
    }
}
