using MyECommerce.Business.Abstract;
using MyECommerce.Business.Concrete;
using MyECommerce.DataLayer.Abstract;
using MyECommerce.DataLayer.Concrete;
using Ninject.Modules;

namespace MyECommerce.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            ////Service Manager
            //Service
            Bind<ICategoryService>().To<ICategoryManager>().InSingletonScope();
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IBasketService>().To<BasketManeger>().InSingletonScope();
            Bind<IUsersService>().To<UsersManeger>().InSingletonScope();
            Bind<IAddressService>().To<AddressManeger>().InSingletonScope();
            Bind<IOrdersService>().To<OrdersManeger>().InSingletonScope();

            //Repository
            Bind<IProductRepository>().To<ProductRepository>().InSingletonScope();
            Bind<ICategoryRepository>().To<CategoryRepository>().InSingletonScope();
            Bind<IBasketRepository>().To<BasketRepository>().InSingletonScope();
            Bind<IUsersRepository>().To<UsersRepository>().InSingletonScope();
            Bind<IAddressRepository>().To<AddressRepository>().InSingletonScope();
            Bind<IOrdersRepository>().To<OrdersRepository>().InSingletonScope();

        }

    }

}
