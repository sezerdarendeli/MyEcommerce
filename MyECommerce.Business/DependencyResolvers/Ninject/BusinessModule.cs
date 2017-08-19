using Ninject.Modules;

namespace MyECommerce.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            ////Service Manager
            //Bind<IMenuService>().To<MenuManager>().InSingletonScope();
        }

    }

}
