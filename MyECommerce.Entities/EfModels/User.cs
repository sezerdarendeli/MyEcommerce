using MyECommerce.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyECommerce.Entities.Concrete
{
    [Table("Users")]
    public class Users:IEntity
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string EMailAdress { get; set; }

        public string Password { get; set; }

        public string ActivationCode { get; set; }

        public DateTime CreatedTime { get; set; }

        public bool Active { get; set; }

        public bool EMailConfirmed { get; set; }
        
    }
}
