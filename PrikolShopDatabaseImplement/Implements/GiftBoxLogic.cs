using PrikolShopBusinessLogic.BindingModels;
using PrikolShopBusinessLogic.Interfaces;
using PrikolShopBusinessLogic.ViewModels;
using PrikolShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PrikolShopDatabaseImplement.Implements
{
    public class GiftBoxLogic : IGiftBoxLogic
    {
        public void CreateOrUpdate(GiftBoxBindingModel model)
        {
            using (var context = new PrikolShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        GiftBox element = context.GiftBoxes.FirstOrDefault(rec =>
                       rec.GiftBoxName == model.GiftBoxName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.GiftBoxes.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new GiftBox();
                            context.GiftBoxes.Add(element);
                        }
                        element.GiftBoxName = model.GiftBoxName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var boxes = context.Boxes.Where(rec
                           => rec.GiftBoxId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.Boxes.RemoveRange(boxes.Where(rec =>
                            !model.Boxes.ContainsKey(rec.GiftId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateGift in boxes)
                            {
                                updateGift.Count =
                               model.Boxes[updateGift.GiftId].Item2;

                                model.Boxes.Remove(updateGift.GiftId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.Boxes)
                        {
                            context.Boxes.Add(new Box
                            {
                                GiftBoxId = element.Id,
                                GiftId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(GiftBoxBindingModel model)
        {
            using (var context = new PrikolShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.Boxes.RemoveRange(context.Boxes.Where(rec =>
                        rec.GiftBoxId == model.Id));
                        GiftBox element = context.GiftBoxes.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.GiftBoxes.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<GiftBoxViewModel> Read(GiftBoxBindingModel model)
        {
            using (var context = new PrikolShopDatabase())
            {
                return context.GiftBoxes
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new GiftBoxViewModel
               {
                   Id = rec.Id,
                   GiftBoxName = rec.GiftBoxName,
                   Price = rec.Price,
                   Boxes = context.Boxes
                .Include(recPC => recPC.Gift)
               .Where(recPC => recPC.GiftBoxId == rec.Id)
               .ToDictionary(recPC => recPC.GiftId, recPC =>
                (recPC.Gift?.GiftName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}
