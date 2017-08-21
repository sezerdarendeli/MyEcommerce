using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyECommerce.WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {



            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Category listesi için  route örn:kategori/bilgisayarlar
            routes.MapRoute(
             name: "CategoryList",
             url: "kategori/{categoryUrlName}",
             defaults: new { controller = "Category", action = "List" }
             );


            // Ürün detay listesi için route örn: urun/iphone-7
            routes.MapRoute(
                name: "ProductDetail",
                url: "urun/{urlName}",
                defaults: new { controller = "Product", action = "Detail" }
            );

            //Sepet sayfası için route.
            routes.MapRoute(
               name: "Basket",
               url: "sepet",
               defaults: new { controller = "ShoppingCart", action = "Index" }
           );

            //Sipariş özeti sayfası route

            routes.MapRoute(
              name: "OrderSummary",
              url: "siparisozeti",
              defaults: new { controller = "ShoppingCart", action = "OrderSummary" }
           );


            //Default route config
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
