using Ninject.Modules;
using Ninject;
namespace MyECommerce.Business.DependencyResolvers.Ninject
{
    public class ResolveModule : NinjectModule
    {
        public override void Load()
        {

            Kernel.Load(new BusinessModule());
        }
    }
}

