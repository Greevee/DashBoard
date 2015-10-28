using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpeakClientMonitor.objects
{
    public class TSClient
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

        public TSClient(string nickname)
        {
            this.nickName = nickname;
        }
    }
}
