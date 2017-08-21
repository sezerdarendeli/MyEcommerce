using MyECommerce.Core.DataAccess;
using MyECommerce.Entities.Concrete;

namespace MyECommerce.DataLayer.Abstract
{
    public interface IOrdersRepository : IEntityRepository<Orders>
    {
    }
}
