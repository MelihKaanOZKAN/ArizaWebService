using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "API Default",
            url: "api/{controller}/{action}/{id}",
            defaults: new { id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Login",
               url: "api/Login/{action}/KullanıcıAdı/Sifre",
               defaults: new { id = UrlParameter.Optional }
           );
           /* routes.MapRoute(
               name: "GetArizaByTarih",
               url: "api/Arizalar/GetArizaByTarih/{baslangic}/{bitis}",
               defaults: new { baslangic = DateTime.MinValue, bitis = DateTime.MinValue }
           );*/
        }
    }
}
