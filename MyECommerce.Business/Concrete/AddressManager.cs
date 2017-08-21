using MyECommerce.Business.Abstract;
using MyECommerce.DataLayer.Abstract;
using MyECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyECommerce.Business.Concrete
{
    public class AddressManeger : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressManeger(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Address Add(Address Address)
        {
            return _addressRepository.Add(Address);
        }

        public List<Address> GetAll()
        {
            return _addressRepository.GetList().ToList();
        }

        public List<Address> GetAll(Expression<Func<Address, bool>> filter)
        {
            return _addressRepository.GetList(filter).ToList();
        }

        public Address GetAddressById(int id)
        {
            return _addressRepository.Get(m => m.Id == id);
        }


        public Address Update(Address Address)
        {
            return _addressRepository.Update(Address);
        }

        public void Delete(Address Address)
        {
            _addressRepository.Delete(Address);
        }

    }
}
