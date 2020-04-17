using PrikolShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrikolShopBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<GiftViewModel> Gifts { get; set; }
    }
}
