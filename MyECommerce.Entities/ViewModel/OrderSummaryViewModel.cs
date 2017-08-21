using System.Collections.Generic;

namespace MyEcommerce.Entities.ViewModel
{
    public class OrderSummaryViewModel : BaseViewModel
    {
        public List<ShoppingCartItemModel> ShoppingCartList { get; set; }

        public double SubTotal { get; set; }
    }
}
