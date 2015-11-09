﻿using Microsoft.Owin.FileSystems;
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

        SystemInfoService systemInfoService = new SystemInfoService();
        TeamSpeakInfoService teamspeakInfoService = new TeamSpeakInfoService();
        SettingsService settingsService = new SettingsService();

        public Configuration getConfiguration()
        {
            return settingsService.getConfig();
        }

        public void startServer()
        {

            var fileSystem = new PhysicalFileSystem(".");
            var options = new FileServerOptions
            {
                EnableDirectoryBrowsing = true,
                FileSystem = fileSystem
            };

            var container = new UnityContainer();
            container.RegisterType<ISystemInfoService, SystemInfoService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITeamSpeakInfoService, TeamSpeakInfoService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISettingsService, SettingsService>(new HierarchicalLifetimeManager());

            container.RegisterInstance<SystemInfoService>(systemInfoService);
            container.RegisterInstance<TeamSpeakInfoService>(teamspeakInfoService);
            container.RegisterInstance<SettingsService>(settingsService);

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
