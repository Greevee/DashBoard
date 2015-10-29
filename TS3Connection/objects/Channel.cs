using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3Connection.objects
{
    public class Channel
    {
        public string id { get; set; }
        public string name { get; set; }
        public Dictionary<string, Client> clients = new Dictionary<string, Client>();

        public Channel(string id)
        {
            this.id = id;
        }
    }
}
