using PrikolShopBusinessLogic.BindingModels;
using PrikolShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrikolShopBusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        List<OrderViewModel> Read(OrderBindingModel model);
        void CreateOrUpdate(OrderBindingModel model);
        void Delete(OrderBindingModel model);
    }
}
