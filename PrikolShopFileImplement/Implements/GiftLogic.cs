using PrikolShopBusinessLogic.BindingModels;
using PrikolShopBusinessLogic.Interfaces;
using PrikolShopBusinessLogic.ViewModels;
using PrikolShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PrikolShopFileImplement.Implements
{
    public class GiftLogic : IGiftLogic
    {
        private readonly FileDataListSingleton source;
        public GiftLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(GiftBindingModel model)
        {
            Gift gift = source.Gifts.FirstOrDefault(rec => rec.GiftName
           == model.GiftName && rec.Id != model.Id);
            if (gift != null)
            {
                throw new Exception("Уже есть подарок с таким названием");
            }
            if (model.Id.HasValue)
            {
                gift = source.Gifts.FirstOrDefault(rec => rec.Id == model.Id);
                if (gift == null)
                {
                    throw new Exception("Подарок не найден");
                }
            }
            else
            {
                int maxId = source.Gifts.Count > 0 ? source.Gifts.Max(rec =>
               rec.Id) : 0;
                gift = new Gift { Id = maxId + 1 };
                source.Gifts.Add(gift);
            }
            gift.GiftName = model.GiftName;
        }
        public void Delete(GiftBindingModel model)
        {
            Gift gift = source.Gifts.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (gift != null)
            {
                source.Gifts.Remove(gift);
            }
            else
            {
            throw new Exception("Подарок не найден");
            }
        }
        public List<GiftViewModel> Read(GiftBindingModel model)
        {
            return source.Gifts
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
