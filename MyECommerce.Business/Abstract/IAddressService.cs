using MyECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyECommerce.Business.Abstract
{
    public interface IAddressService
    {
        List<Address> GetAll();

        Address Add(Address Address);

        Address GetAddressById(int id);

        Address Update(Address Address);

        List<Address> GetAll(Expression<Func<Address, bool>> filter);

        void Delete(Address Address);
    }
}
