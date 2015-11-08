using RainbowDashBoard.Models;
using RainbowDashBoard.Models.Hardware.Ram;
using RainbowDashBoard.Models.TeamSpeak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TS3Connection;

namespace RainbowDashBoard.Controllers.TeamSpeak
{
    public class TeamSpeakInfoController : ApiController
    {
        private ITeamSpeakInfoService service;

        public TeamSpeakInfoController(ITeamSpeakInfoService service)
        {
            this.service = service;
        }

        public TeamSpeakInfo Get()
        {
            return service.getTeamSpeakInfo();
        }
    }
}
