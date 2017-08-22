using MyECommerce.WebApplication.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyECommerce.WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());


        }
    }
}
