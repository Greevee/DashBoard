using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3Connection.objects
{
    public class Channel
    {
        string id { get; set; }
        string name { get; set; }

        public Channel(string id)
        {
            this.id = id;
        }
    }
}
