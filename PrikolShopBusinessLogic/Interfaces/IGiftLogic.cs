using System.Collections.Generic;
using PrikolShopBusinessLogic.BindingModels;
using PrikolShopBusinessLogic.ViewModels;

namespace PrikolShopBusinessLogic.Interfaces
{
    public interface IGiftLogic
    {
        List<GiftViewModel> Read(GiftBindingModel model);
        void CreateOrUpdate(GiftBindingModel model);
        void Delete(GiftBindingModel model);
    }
}
