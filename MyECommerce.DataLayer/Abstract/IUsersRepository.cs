using MyECommerce.Core.DataAccess;
using MyECommerce.Entities.Concrete;

namespace MyECommerce.DataLayer.Abstract
{
    public interface IUsersRepository : IEntityRepository<Users>
    {
    }
}
