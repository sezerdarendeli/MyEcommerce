using MyECommerce.Business.Abstract;
using MyECommerce.DataLayer.Abstract;
using MyECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyECommerce.Business.Concrete
{
    public class BasketManeger : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketManeger(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public Basket Add(Basket Basket)
        {
            return _basketRepository.Add(Basket);
        }

        public List<Basket> GetAll()
        {
            return _basketRepository.GetList().ToList();
        }

        public List<Basket> GetAll(Expression<Func<Basket, bool>> filter)
        {
            return _basketRepository.GetList(filter).ToList();
        }

        public Basket GetBasketById(int id)
        {
            return _basketRepository.Get(m => m.Id == id);
        }


        public Basket Update(Basket Basket)
        {
            return _basketRepository.Update(Basket);
        }


        public void Delete(Basket Basket)
        {
            _basketRepository.Delete(Basket);
        }

    }
}
