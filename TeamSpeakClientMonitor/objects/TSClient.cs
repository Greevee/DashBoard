using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpeakClientMonitor.objects
{
    class TSClient
    {
        public enum ClientState
        {
            normal,
            micmuted,
            soundmuted,
            away
        };
        public string id { get; set; }
        public string nickName { get; set; }
        public ClientState state { get; set; }



    }
}
