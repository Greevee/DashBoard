using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerDashBoard.Models.Configuration
{
    public class Configuration
    {
        public Modul.NetworkConfiguration networkConfig { get; set; }
        public Modul.ClockConfiguration clockConfig { get; set; }
        public Modul.CPUConfiguration cpuConfig { get; set; }
        public Modul.MemoryConfiguration memoryConfig { get; set; }
        public Modul.TeamSpeakConfiguration tsconfig { get; set; }
        public Modul.StyleConfiguration styleconig { get; set; }
    }
}
