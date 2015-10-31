using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS3Connection;

namespace GamerDashBoard.Models
{
    class TeamSpeakInfoService : ITeamSpeakInfoService
    {
        TSConnection ts3 = new TSConnection();

        public TeamSpeakInfoService()
        {
            ts3.Connect();
        }

        public string test()
        {
            return "test";
        }
    }
}
