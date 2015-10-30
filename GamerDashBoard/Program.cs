using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.StaticFiles;
using Owin;
using System;
using System.Net.Http;
using System.Web.Http;
using GamerDashBoard.Resolver;
using GamerDashBoard.Models;
using Microsoft.Practices.Unity;

namespace PlayGround2
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:13337";
            var root = args.Length > 0 ? args[0] : ".";
            var fileSystem = new PhysicalFileSystem(root);



            var options = new FileServerOptions
            {
                EnableDirectoryBrowsing = true,
                FileSystem = fileSystem
            };


            var urlApi = "http://localhost:13338";


            SystemInfoService systemInfoService = new SystemInfoService();

            var container = new UnityContainer();
            container.RegisterType<ISystemInfoService, SystemInfoService>(new HierarchicalLifetimeManager());
            container.RegisterInstance<SystemInfoService>(systemInfoService);


            


            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = new UnityResolver(container);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );



            //WebApp.Start(urlApi, builder => builder.UseWebApi(config));
            WebApp.Start(url, builder => builder.UseFileServer(options).UseWebApi(config));
            Console.WriteLine("Listening at " + url);
            Console.ReadLine();






        }
    }
}
