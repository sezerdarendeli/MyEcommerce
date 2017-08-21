using MyECommerce.Business.Abstract;
using MyECommerce.DataLayer.Abstract;
using MyECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyECommerce.Business.Concrete
{
    public class OrdersManeger : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersManeger(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public Orders Add(Orders Orders)
        {
            return _ordersRepository.Add(Orders);
        }

        public List<Orders> GetAll()
        {
            return _ordersRepository.GetList().ToList();
        }

        public List<Orders> GetAll(Expression<Func<Orders, bool>> filter)
        {
            return _ordersRepository.GetList(filter).ToList();
        }

        public Orders GetOrdersById(int id)
        {
            return _ordersRepository.Get(m => m.Id == id);
        }


        public Orders Update(Orders Orders)
        {
            return _ordersRepository.Update(Orders);
        }

        public void Delete(Orders Orders)
        {
            _ordersRepository.Delete(Orders);
        }

    }
}
