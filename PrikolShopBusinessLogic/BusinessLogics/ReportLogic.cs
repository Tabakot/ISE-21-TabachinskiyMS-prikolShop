using PrikolShopBusinessLogic.BindingModels;
using PrikolShopBusinessLogic.HelperModels;
using PrikolShopBusinessLogic.Interfaces;
using PrikolShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrikolShopBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IGiftLogic GiftLogic;
        private readonly IGiftBoxLogic GiftBoxLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IGiftBoxLogic GiftBoxLogic, IGiftLogic GiftLogic,
       IOrderLogic orderLogic)
        {
            this.GiftBoxLogic = GiftBoxLogic;
            this.GiftLogic = GiftLogic;
            this.orderLogic = orderLogic;
        }

        public List<ReportBoxViewModel> GetBox()
        {
            var GiftBoxes = GiftBoxLogic.Read(null);
            var list = new List<ReportBoxViewModel>();
            foreach (var giftBox in GiftBoxes)
            {
                foreach (var b in giftBox.Boxes)
                {
                    var record = new ReportBoxViewModel
                    {
                        GiftBoxName = giftBox.GiftBoxName,
                        GiftName = b.Value.Item1,
                        Count = b.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }

        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
            .Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .GroupBy(rec => rec.DateCreate.Date)
            .OrderBy(recG => recG.Key)
            .ToList();

            return list;
        }
        
        public void SaveGiftsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список подарков",
                Gifts = GiftLogic.Read(null)
            });
        }

        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }
        
        public void SaveGiftBoxesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список подарочных наборов по подаркам",
                Boxes = GetBox(),
            });
        }
    }
}