using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerDashBoard.Models.TeamSpeak
{
    public class TeamSpeakChannelInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public Dictionary<string, TeamSpeakClientInfo> clients { get; set; }
    }
}
