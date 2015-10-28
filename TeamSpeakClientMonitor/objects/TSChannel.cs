using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpeakClientMonitor.objects
{
    class TSChannel
    {
        public string id { get; set; }
        public string channelName { get; set; }
        public HashSet<TSClient> clients { get; set; }
    }
}
