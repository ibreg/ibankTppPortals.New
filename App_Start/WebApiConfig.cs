using System;
using System.Web.Http;

namespace ibankTppPortals.New
{
    public static class WebApiConfig
    {
        public static void Configure()
        {
            try
            {
                GlobalConfiguration.Configure((httpConf) =>
                {
                    RegisterRoutes(httpConf);
                });
            }
            catch (Exception ex)
            {
            }
        }

        private static void RegisterRoutes(HttpConfiguration config)
        {

            config.MapHttpAttributeRoutes();
            config.Routes.IgnoreRoute("dist", "dist/{*pathInfo}");
            config.Routes.IgnoreRoute("Content", "Content/{*pathInfo}");

            config.Routes.MapHttpRoute(
                    name: "Index",
                    routeTemplate: "",
                    defaults: new { controller = "Index", action = "Get" }
            );

            config.Routes.MapHttpRoute(
                name: "internalAction",
                routeTemplate: "{controller}/{action}",
                defaults: new { controller = "{controller}", action = "{action}" }
            );

            config.Routes.MapHttpRoute(
                name: "Error404",
                routeTemplate: "{*url}",
                defaults: new { controller = "Index", action = "Get" }
            );
        }
    }
}