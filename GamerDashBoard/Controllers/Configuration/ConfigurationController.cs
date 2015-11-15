using GamerDashBoard.Models;
using GamerDashBoard.Models.Hardware.Ram;
using GamerDashBoard.Models.TeamSpeak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GamerDashBoard.Models.Configuration;

namespace GamerDashBoard.Controllers.Configuration
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
