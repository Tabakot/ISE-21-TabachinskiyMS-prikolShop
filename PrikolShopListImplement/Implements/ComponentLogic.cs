using PrikolShopBusinessLogic.BindingModels;
using PrikolShopBusinessLogic.Interfaces;
using PrikolShopBusinessLogic.ViewModels;
using PrikolShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrikolShopListImplement.Implements
{
    public class GiftLogic : IGiftLogic
    {
        private readonly DataListSingleton source;
        public GiftLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(GiftBindingModel model)
        {
            Gift tempGift = model.Id.HasValue ? null : new Gift
            {
                Id = 1
            };
            foreach (var gift in source.Gifts)
            {
                if (gift.GiftName == model.GiftName && gift.Id !=
               model.Id)
                {
                    throw new Exception("Уже есть подарок с таким названием");
                }
                if (!model.Id.HasValue && gift.Id >= tempGift.Id)
                {
                    tempGift.Id = gift.Id + 1;
                }
                else if (model.Id.HasValue && gift.Id == model.Id)
                {
                    tempGift = gift;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempGift == null)
                {
                    throw new Exception("Подарок не найден");
                }
                CreateModel(model, tempGift);
            }
            else
            {
                source.Gifts.Add(CreateModel(model, tempGift));
            }
        }
        public void Delete(GiftBindingModel model)
        {
            for (int i = 0; i < source.Gifts.Count; ++i)
            {
                if (source.Gifts[i].Id == model.Id.Value)
                {
                    source.Gifts.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Подарок не найден");
        }
        public List<GiftViewModel> Read(GiftBindingModel model)
        {
            List<GiftViewModel> result = new List<GiftViewModel>();
            foreach (var gift in source.Gifts)
            {
                if (model != null)
                {
                    if (gift.Id == model.Id)
                    {
                        result.Add(CreateViewModel(gift));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(gift));
            }
            return result;
        }
        private Gift CreateModel(GiftBindingModel model, Gift gift)
        {
            gift.GiftName = model.GiftName;
            return gift;
        }
        private GiftViewModel CreateViewModel(Gift gift)
        {
            return new GiftViewModel
            {
                Id = gift.Id,
                GiftName = gift.GiftName
            };
        }
    }
}
