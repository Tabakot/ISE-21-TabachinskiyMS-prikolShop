using System;
using System.Collections.Generic;
using System.Text;

namespace PrikolShopBusinessLogic.ViewModels
{
    public class ReportBoxViewModel
    {
        public string GiftName { get; set; }

        public int TotalCount { get; set; }

        public List<Tuple<string, int>> GiftBoxes { get; set; }
    }
}
