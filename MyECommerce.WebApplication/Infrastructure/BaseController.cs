using MyECommerce.Entities.ComlexTypes;
using System.Web.Mvc;

namespace MyEcommerce.Web.Infrastructure
{
    public class BaseController : Controller
    {
        public UserSession UserSession
        {
            get
            {
                if(Session["UserSession"] ==null)
                {
                    var userSession = new UserSession();
                    Session["UserSession"] = userSession;
                    return (UserSession)Session["UserSession"];
                } 
                else
                {
                    return (UserSession)Session["UserSession"];
                }
                    
            }
            set
            {
                Session["UserSession"] = value;
            }

        }
    }
}