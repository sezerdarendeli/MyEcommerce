using MyECommerce.Core.DataAccess.EntityFramework;
using MyECommerce.DataLayer.Abstract;
using MyECommerce.DataLayer.DataContext;
using MyECommerce.Entities.Concrete;

namespace MyECommerce.DataLayer.Concrete
{
    public class ProductRepository : EfEntityRepositoryBase<Product, MyECommerceDataContext>, IProductRepository
    {
    }
}
