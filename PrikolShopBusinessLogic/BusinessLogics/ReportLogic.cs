using PrikolShopBusinessLogic.BindingModels;
using PrikolShopBusinessLogic.HelperModels;
using PrikolShopBusinessLogic.Interfaces;
using PrikolShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrikolShopBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IGiftLogic giftLogic;

        private readonly IGiftBoxLogic giftBoxLogic;

        private readonly IOrderLogic orderLogic;

        public ReportLogic(IGiftBoxLogic giftBoxLogic, IGiftLogic giftLogic, IOrderLogic orderLLogic)
        {
            this.giftBoxLogic = giftBoxLogic;
            this.giftLogic = giftLogic;
            this.orderLogic = orderLLogic;
        }

        /// <summary> 
        /// Получение списка компонент с указанием, в каких изделиях используются 
        /// </summary>   
        /// <returns></returns>
        public List<ReportBoxViewModel> GetBox()
        {
            var gifts = giftLogic.Read(null);

            var giftBoxes = giftBoxLogic.Read(null);

            var list = new List<ReportBoxViewModel>();

            foreach (var gift in gifts)
            {
                var record = new ReportBoxViewModel
                { 
                    GiftName = gift.GiftName,
                    GiftBoxes = new List<Tuple<string, int>>(),
                    TotalCount = 0 
                };

                foreach (var giftBox in giftBoxes)
                {
                    if (giftBox.Boxes.ContainsKey(gift.Id)) 
                    {
                        record.GiftBoxes.Add(new Tuple<string, int>(giftBox.GiftBoxName,
                            giftBox.Boxes[gift.Id].Item2));
                        record.TotalCount += giftBox.Boxes[gift.Id].Item2;
                    }
                }

                list.Add(record);
            }

            return list;
        }

        /// <summary>        
        /// Получение списка заказов за определенный период     
        /// </summary>    
        /// <param name="model"></param>     
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model) 
        {
            return orderLogic.Read(new OrderBindingModel 
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo 
            }).Select(x => new ReportOrdersViewModel 
            {
                DateCreate = x.DateCreate,
                GiftBoxName = x.GiftBoxName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            }).ToList();
        }

        /// <summary> 
        /// Сохранение компонент в файл-Word 
        /// </summary> 
        /// <param name="model"></param> 
        public void SaveComponentsToWordFile(ReportBindingModel model) 
        {
            SaveToWord.CreateDoc(new WordInfo 
            {
                FileName = model.FileName,
                Title = "Список подарков",
                Gifts = giftLogic.Read(null)
            });
        }

        /// <summary>    
        /// Сохранение компонент с указаеним продуктов в файл-Excel    
        /// </summary>       
        /// <param name="model"></param> 
        public void SaveProductComponentToExcelFile(ReportBindingModel model) 
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            { 
                FileName = model.FileName,
                Title = "Список подарков",
                Boxes = GetBox()
            });
        }

        /// <summary>      
        /// Сохранение заказов в файл-Pdf      
        /// </summary>     
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        { 
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
