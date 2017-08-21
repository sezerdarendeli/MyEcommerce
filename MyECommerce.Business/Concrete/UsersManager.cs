using MyECommerce.Business.Abstract;
using MyECommerce.DataLayer.Abstract;
using MyECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyECommerce.Business.Concrete
{
    public class UsersManeger : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersManeger(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Users Add(Users Users)
        {
            return _usersRepository.Add(Users);
        }

        public List<Users> GetAll()
        {
            return _usersRepository.GetList().ToList();
        }

        public Users Get(Expression<Func<Users, bool>> filter)
        {
            return _usersRepository.Get(filter);
        }

        public Users GetUsersById(int id)
        {
            return _usersRepository.Get(m => m.Id == id);
        }
        

        public Users Update(Users Users)
        {
            return _usersRepository.Update(Users);
        }
      
    }
}
