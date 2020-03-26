using System.ComponentModel;

namespace PrikolShopBusinessLogic.ViewModels
{
    public class GiftViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название подарка")]
        public string GiftName { get; set; }
    }
}
