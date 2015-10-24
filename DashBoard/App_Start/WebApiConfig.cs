using DashBoard.Models;
using Microsoft.Practices.Unity;
using System.Web.Http;
using DashBoard.Resolver;
namespace DashBoard
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services


            SystemInfoService systemInfoService = new SystemInfoService();

            var container = new UnityContainer();
            container.RegisterType<ISystemInfoService, SystemInfoService>(new HierarchicalLifetimeManager());
            container.RegisterInstance<SystemInfoService>(systemInfoService);


            config.DependencyResolver = new UnityResolver(container);


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
