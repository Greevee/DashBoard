using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowDashBoard.Models.Configuration.Modul
{
    public class ClockConfiguration
    {
        public bool enabled = true;
        public int alarmSeconds = 900;

        public ClockConfiguration()
        {
            this.enabled = true;
        }
    }
}
