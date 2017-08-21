using MyECommerce.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyECommerce.Entities.Concrete
{
    [Table("Basket")]
    public class Basket : IEntity
    {
        public int Id { get; set; }

        public bool Active { get; set; }

        public int BasketId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedTime { get; set; }


    }
}
