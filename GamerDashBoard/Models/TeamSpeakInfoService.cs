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

        public TeamSpeakInfoService()
        {
            ts3 = new TS3Connection.TSConnection();
            Thread t = new Thread(new ThreadStart(ts3.Connect));
            t.Start();
        }

        public TeamSpeakState test()
        {
            TeamSpeakState teamspeakState = new TeamSpeakState();
            teamspeakState.myClient = ts3.myClient;
            teamspeakState.myChannel = ts3.myChannel;
            return teamspeakState;
        }
    }
}
