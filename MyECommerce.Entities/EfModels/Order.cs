using MyECommerce.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyECommerce.Entities.Concrete
{
    [Table("Orders")]
    public class Orders : IEntity
    {
        public int Id { get; set; }

        public int BasketId { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int AddressId { get; set; }

    }
}
