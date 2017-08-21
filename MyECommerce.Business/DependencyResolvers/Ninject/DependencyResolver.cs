using Ninject;

namespace MyECommerce.Business.DependencyResolvers.Ninject
{
    public class DependencyResolver<T>
    {
        public static T Resolve()
        {
            IKernel kernel = new StandardKernel(new ResolveModule());

            return kernel.Get<T>();
        }
    }
}

