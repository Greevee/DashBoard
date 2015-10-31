using GamerDashBoard.Models;
using GamerDashBoard.Models.Hardware.Ram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GamerDashBoard.Controllers.TeamSpeak
{
    public class TeamSpeakInfoController : ApiController
    {
        private ITeamSpeakInfoService service;

        public TeamSpeakInfoController(ITeamSpeakInfoService service)
        {
            this.service = service;
        }

        public string Get()
        {
            return service.test();
        }
    }
}
