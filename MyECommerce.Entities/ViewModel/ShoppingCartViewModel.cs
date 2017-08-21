using System.Collections.Generic;

namespace MyEcommerce.Entities.ViewModel
{
    public class ShoppingCartViewModel : BaseViewModel
    {
        public List<ShoppingCartItemModel> ShoppingCartList { get; set; }

        public double SubTotal { get; set; }

        public string  Address { get; set; }

    }
}
