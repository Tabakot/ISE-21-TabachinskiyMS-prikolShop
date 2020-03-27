using PrikolShopBusinessLogic.BindingModels;
using PrikolShopBusinessLogic.Interfaces;
using PrikolShopBusinessLogic.ViewModels;
using PrikolShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PrikolShopDatabaseImplement.Implements
{
    public class GiftLogic : IGiftLogic
    {
        public void CreateOrUpdate(GiftBindingModel model)
        {
            using (var context = new PrikolShopDatabase())
            {
                Gift element = context.Gifts.FirstOrDefault(rec =>
               rec.GiftName == model.GiftName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть подарок с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Gifts.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Gift();
                    context.Gifts.Add(element);
                }
                element.GiftName = model.GiftName;
                context.SaveChanges();
            }
        }
        public void Delete(GiftBindingModel model)
        {
            using (var context = new PrikolShopDatabase())
            {
                Gift element = context.Gifts.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Gifts.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<GiftViewModel> Read(GiftBindingModel model)
        {
            using (var context = new PrikolShopDatabase())
            {
                return context.Gifts
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new GiftViewModel
                {
                    Id = rec.Id,
                    GiftName = rec.GiftName
                })
                .ToList();
            }
        }
    }

}
