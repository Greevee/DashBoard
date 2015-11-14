using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.StaticFiles;
using Owin;
using System;
using System.Net.Http;
using System.Web.Http;
using RainbowDashBoard.Resolver;
using RainbowDashBoard.Models;
using Microsoft.Practices.Unity;
using RainbowDashBoard.Models.Configuration;

namespace RainbowDashBoard
{
    public class Server
    {

        public SystemInfoService systemInfoService;
        public TeamSpeakInfoService teamspeakInfoService;
        public ConfigurationService settingsService;
        Configuration serverConfig;

        public Configuration getConfiguration()
        {
            return serverConfig;
        }

        public void startServer()
        {

            settingsService = new ConfigurationService();
            serverConfig = settingsService.getConfig();
            //TODO disable deactivated modules

            systemInfoService = new SystemInfoService();
            teamspeakInfoService = new TeamSpeakInfoService();
           


            var fileSystem = new PhysicalFileSystem(".");
            var options = new FileServerOptions
            {
                EnableDirectoryBrowsing = true,
                FileSystem = fileSystem
            };

            var container = new UnityContainer();
            container.RegisterType<ISystemInfoService, SystemInfoService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITeamSpeakInfoService, TeamSpeakInfoService>(new HierarchicalLifetimeManager());
            container.RegisterType<IConfigurationService, ConfigurationService>(new HierarchicalLifetimeManager());

            container.RegisterInstance<SystemInfoService>(systemInfoService);
            container.RegisterInstance<TeamSpeakInfoService>(teamspeakInfoService);
            container.RegisterInstance<ConfigurationService>(settingsService);

            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = new UnityResolver(container);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            StartOptions urls = new StartOptions();

            urls.Urls.Add("http://*:13337");

            WebApp.Start(urls, builder => builder.UseFileServer(options).UseWebApi(config));
        }

    }
}
