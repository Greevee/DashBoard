using RainbowDashBoard.Models;
using RainbowDashBoard.Models.Hardware.Ram;
using RainbowDashBoard.Models.TeamSpeak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RainbowDashBoard.Models.Configuration;

namespace RainbowDashBoard.Controllers.Configuration
{
    public class ConfigurationController : ApiController
    {
        private IConfigurationService service;

        public ConfigurationController(IConfigurationService service)
        {
            this.service = service;
        }

        public Models.Configuration.Configuration get()
        {
            return service.getConfig();
        }
    }
}
