using PrikolShopBusinessLogic.BindingModels;
using PrikolShopBusinessLogic.Interfaces;
using PrikolShopBusinessLogic.ViewModels;
using PrikolShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrikolShopListImplement.Implements
{
    public class GiftBoxLogic : IGiftBoxLogic
    {
        private readonly DataListSingleton source;
        public GiftBoxLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(GiftBoxBindingModel model)
        {
            GiftBox tempGiftBox = model.Id.HasValue ? null : new GiftBox { Id = 1 };
            foreach (var giftBox in source.GiftBoxes)
            {
                if (giftBox.GiftBoxName == model.GiftBoxName && giftBox.Id != model.Id)
                {
                    throw new Exception("Уже есть подарочный набор с таким названием");
                }
                if (!model.Id.HasValue && giftBox.Id >= tempGiftBox.Id)
                {
                    tempGiftBox.Id = giftBox.Id + 1;
                }
                else if (model.Id.HasValue && giftBox.Id == model.Id)
                {
                    tempGiftBox = giftBox;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempGiftBox == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempGiftBox);
            }
            else
            {
                source.GiftBoxes.Add(CreateModel(model, tempGiftBox));
            }
        }
        public void Delete(GiftBoxBindingModel model)
        {
            for (int i = 0; i < source.Boxes.Count; ++i)
            {
                if (source.Boxes[i].GiftBoxId == model.Id)
                {
                    source.Boxes.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.GiftBoxes.Count; ++i)
            {
                if (source.GiftBoxes[i].Id == model.Id)
                {
                    source.GiftBoxes.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private GiftBox CreateModel(GiftBoxBindingModel model, GiftBox giftBox)
        {
            giftBox.GiftBoxName = model.GiftBoxName;
            giftBox.Price = model.Price;

            int maxPCId = 0;
            for (int i = 0; i < source.Boxes.Count; ++i)
            {
                if (source.Boxes[i].Id > maxPCId)
                {
                    maxPCId = source.Boxes[i].Id;
                }
                if (source.Boxes[i].GiftBoxId == giftBox.Id)
                {
                    if
                    (model.Boxes.ContainsKey(source.Boxes[i].GiftId))
                    {
                        source.Boxes[i].Count =
                        model.Boxes[source.Boxes[i].GiftId].Item2;
                        model.Boxes.Remove(source.Boxes[i].GiftId);
                    }
                    else
                    {
                        source.Boxes.RemoveAt(i--);
                    }
                }
            }

            foreach (var pc in model.Boxes)
            {
                source.Boxes.Add(new Box
                {
                    Id = ++maxPCId,
                    GiftBoxId = giftBox.Id,
                    GiftId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return giftBox;
        }
        public List<GiftBoxViewModel> Read(GiftBoxBindingModel model)
        {
            List<GiftBoxViewModel> result = new List<GiftBoxViewModel>();
            foreach (var gift in source.GiftBoxes)
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
        private GiftBoxViewModel CreateViewModel(GiftBox giftBox)
        {
        Dictionary<int, (string, int)> boxes = new Dictionary<int,
(string, int)>();
            foreach (var pc in source.Boxes)
            {
                if (pc.GiftBoxId == giftBox.Id)
                {
                    string giftName = string.Empty;
                    foreach (var gift in source.Gifts)
                    {
                        if (pc.GiftId == gift.Id)
                        {
                            giftName = gift.GiftName;
                            break;
                        }
                    }
                    boxes.Add(pc.GiftId, (giftName, pc.Count));
                }
            }
            return new GiftBoxViewModel
            {
                Id = giftBox.Id,
                GiftBoxName = giftBox.GiftBoxName,
                Price = giftBox.Price,
                Boxes = boxes
            };
        }
    }
}
