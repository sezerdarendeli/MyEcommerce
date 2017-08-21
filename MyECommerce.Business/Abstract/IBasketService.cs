using MyECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyECommerce.Business.Abstract
{
    public interface IBasketService
    {
        List<Basket> GetAll();

        Basket Add(Basket Basket);

        Basket GetBasketById(int id);

        Basket Update(Basket Basket);

        List<Basket> GetAll(Expression<Func<Basket, bool>> filter);

        void Delete(Basket Basket);
    }
}
