using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpeakClientMonitor.objects
{
    public class TSChannel
    {
        private string channelID;

        public TSChannel(string channelID)
        {
            this.channelID = channelID;
        }

        public string id { get; set; }
        public string channelName { get; set; }
        public Dictionary<string,TSClient> clients { get; set; } 
    }
}
