using System.Collections.Generic;
using PrikolShopBusinessLogic.BindingModels;
using PrikolShopBusinessLogic.ViewModels;

namespace PrikolShopBusinessLogic.Interfaces
{
    public interface IGiftBoxLogic
    {
        List<GiftBoxViewModel> Read(GiftBoxBindingModel model);
        void CreateOrUpdate(GiftBoxBindingModel model);
        void Delete(GiftBoxBindingModel model);
    }
}
