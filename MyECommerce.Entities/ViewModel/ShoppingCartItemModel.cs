using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommerce.Entities.ViewModel
{
    public class ShoppingCartItemModel
    {
        public string ProductName { get; set; }

        public int ProductId { get; set; }

        public double Price { get; set; }
        
        public int Quantity { get; set; }

        public string ProductImageUrl { get; set; }
        public double ItemTotalPrice { get; set; }
    }
}
