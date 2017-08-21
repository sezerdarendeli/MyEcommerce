using Autofac;
using Autofac.Integration.Mvc;
using MyECommerce.Business.Abstract;
using MyECommerce.Business.Concrete;
using MyECommerce.DataLayer.Abstract;
using MyECommerce.DataLayer.Concrete;
using MyECommerce.WebApplication.Infrastructure;
using System.Reflection;
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
