using MyECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyECommerce.Entities.ViewModel
{
    public class UserDetailViewModel
    {
        public Users User { get; set; }

        public List<Orders> OrderList {get;set;}
    }
}
