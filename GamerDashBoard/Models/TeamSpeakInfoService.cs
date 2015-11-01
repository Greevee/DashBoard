using GamerDashBoard.Models.TeamSpeak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TS3Connection;
using GamerDashBoard.Models.TeamSpeak;

namespace GamerDashBoard.Models
{
    class TeamSpeakInfoService : ITeamSpeakInfoService
    {
        TSConnection ts3;
        TeamSpeakInfoFactory teamSpeakInfoFactory;

        public TeamSpeakInfoService()
        {
            ts3 = new TS3Connection.TSConnection();
            Thread t = new Thread(new ThreadStart(ts3.Connect));
            t.Start();
            teamSpeakInfoFactory = new TeamSpeakInfoFactory(ts3);
        }

        public TeamSpeakInfo getTeamSpeakInfo()
        {
            TeamSpeakInfo teamspeakState = teamSpeakInfoFactory.GetTeamSpeakInfo();

            return teamspeakState;
        }
    }
}
