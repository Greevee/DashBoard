using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerDashBoard.Models.Configuration.Modul
{
    public class NetworkConfiguration 
    {
        public string interfaceName { get; set; }
        public bool enabled = true;

        public NetworkConfiguration()
        {
            this.interfaceName = "";
            this.enabled = true;
        }
    }
}
