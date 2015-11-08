using RainbowDashBoard.Models.TeamSpeak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TS3Connection;

namespace RainbowDashBoard.Models
{
    class TeamSpeakInfoService : ITeamSpeakInfoService
    {
        TSConnection ts3;
        TeamSpeakInfoFactory teamSpeakInfoFactory;
        Thread t;

        public TeamSpeakInfoService()
        {
            ts3 = new TS3Connection.TSConnection();
            t = new Thread(new ThreadStart(ts3.Connect));
            t.Start();
            teamSpeakInfoFactory = new TeamSpeakInfoFactory(ts3);
        }

        public TeamSpeakInfo getTeamSpeakInfo()
        {
            return teamSpeakInfoFactory.GetTeamSpeakInfo();
        }
    }
}
