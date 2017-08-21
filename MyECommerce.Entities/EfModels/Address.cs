using MyECommerce.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyECommerce.Entities.Concrete
{
    [Table("Address")]
    public class Address:IEntity
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }

        public string AddresName { get; set; }

        public string NameSurName { get; set; }

        public string AddressText { get; set; }

    }
}
