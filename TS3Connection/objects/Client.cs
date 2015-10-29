using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3Connection.objects
{

    public enum clientState
    {
        normal,
        mic_muted,
        speaker_muted,
        away
    }

    public class Client
    {
        string id { get; set; }
        string nickname { get; set; }
        clientState state { get; set; }

        public Client(string id)
        {
            this.id = id;
        }

    }


}
