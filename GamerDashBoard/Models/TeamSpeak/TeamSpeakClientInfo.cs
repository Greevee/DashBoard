using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowDashBoard.Models.TeamSpeak
{
    public class TeamSpeakClientInfo
    {
        public string id { get; set; }
        public string nickname { get; set; }
        public bool isTalking { get; set; }
        public string client_status { get; set; }
    }
}
