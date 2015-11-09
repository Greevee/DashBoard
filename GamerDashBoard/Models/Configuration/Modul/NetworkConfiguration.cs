using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowDashBoard.Models.Configuration.Modul
{
    class NetworkConfiguration : Modul.IModulConfiguration
    {
        public string interfaceName { get; set; }
        private bool enabled = false;

        public bool isEnabled()
        {
            if (enabled == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
