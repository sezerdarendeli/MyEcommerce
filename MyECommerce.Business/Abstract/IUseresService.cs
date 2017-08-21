using MyECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyECommerce.Business.Abstract
{
    public interface IUsersService
    {
        List<Users> GetAll();

        Users Add(Users Users);

        Users GetUsersById(int id);

        Users Update(Users Users);

        Users Get(Expression<Func<Users, bool>> filter);
    }
}
