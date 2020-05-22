using PrikolShopBusinessLogic.BindingModels;
using PrikolShopBusinessLogic.Interfaces;
using PrikolShopBusinessLogic.ViewModels;
using PrikolShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrikolShopFileImplement.Implements
{
    public class GiftBoxLogic : IGiftBoxLogic
    {
        private readonly FileDataListSingleton source;
        public GiftBoxLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(GiftBoxBindingModel model)
        {
            GiftBox giftBox = source.GiftBoxes.FirstOrDefault(rec => rec.GiftBoxName ==
           model.GiftBoxName && rec.Id != model.Id);
            if (giftBox != null)
            {
                throw new Exception("Уже есть подарочный набор с таким названием");
            }
            if (model.Id.HasValue)
            {
                giftBox = source.GiftBoxes.FirstOrDefault(rec => rec.Id == model.Id);
                if (giftBox == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.GiftBoxes.Count > 0 ? source.Gifts.Max(rec =>
               rec.Id) : 0;
                giftBox = new GiftBox { Id = maxId + 1 };
                source.GiftBoxes.Add(giftBox);
            }
            giftBox.GiftBoxName = model.GiftBoxName;
            giftBox.Price = model.Price;
            // удалили те, которых нет в модели
            source.Boxes.RemoveAll(rec => rec.GiftBoxId == model.Id &&
           !model.Boxes.ContainsKey(rec.GiftId));
            // обновили количество у существующих записей
            var updateGifts = source.Boxes.Where(rec => rec.GiftBoxId ==
           model.Id && model.Boxes.ContainsKey(rec.GiftId));
            foreach (var updateGift in updateGifts)
            {
                updateGift.Count =
               model.Boxes[updateGift.GiftId].Item2;
                model.Boxes.Remove(updateGift.GiftId);
            }
            // добавили новые
            int maxPCId = source.Boxes.Count > 0 ?
           source.Boxes.Max(rec => rec.Id) : 0;

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
        }
        public void Delete(GiftBoxBindingModel model)
        {
            // удаяем записи по компонентам при удалении изделия
            source.Boxes.RemoveAll(rec => rec.GiftBoxId == model.Id);
            GiftBox giftBox = source.GiftBoxes.FirstOrDefault(rec => rec.Id == model.Id);
            if (giftBox != null)
            {
                source.GiftBoxes.Remove(giftBox);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<GiftBoxViewModel> Read(GiftBoxBindingModel model)
        {
            return source.GiftBoxes
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new GiftBoxViewModel
            {
                Id = rec.Id,
                GiftBoxName = rec.GiftBoxName,
                Price = rec.Price,
                Boxes = source.Boxes
            .Where(recPC => recPC.GiftBoxId == rec.Id)
            .ToDictionary(recPC => recPC.GiftId, recPC =>
            (source.Gifts.FirstOrDefault(recC => recC.Id ==
           recPC.GiftId)?.GiftName, recPC.Count))
            })
            .ToList();
        }
    }
}
