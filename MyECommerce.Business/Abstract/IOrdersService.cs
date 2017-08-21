using MyECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyECommerce.Business.Abstract
{
    public interface IOrdersService
    {
        List<Orders> GetAll();

        Orders Add(Orders Orders);

        Orders GetOrdersById(int id);

        Orders Update(Orders Orders);

        List<Orders> GetAll(Expression<Func<Orders, bool>> filter);

        void Delete(Orders Orders);
    }
}
