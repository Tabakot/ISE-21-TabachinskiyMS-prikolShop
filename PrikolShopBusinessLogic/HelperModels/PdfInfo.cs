using PrikolShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrikolShopBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportBoxViewModel> Boxes { get; set; }
    }
}
