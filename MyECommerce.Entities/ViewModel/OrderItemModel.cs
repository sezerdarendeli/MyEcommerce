using System;

namespace MyEcommerce.Entities.ViewModel
{
    public class OrderItemModel
    {
        public int OrderId { get; set; }

        public DateTime OrderTime { get; set; }

        public double OrderSubTotal { get; set; }
    }
}
