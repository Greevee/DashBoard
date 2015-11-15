using GamerDashBoard.Models.Configuration.Modul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerDashBoard.Models.Configuration
{
    class ConfigurationFactory
    {
        public static  Configuration CreateConfig()
        {
            Configuration config = new Configuration();
            NetworkConfiguration networkcon = new NetworkConfiguration();
            ClockConfiguration clockcon = new ClockConfiguration();
            CPUConfiguration cpuconfig = new CPUConfiguration();
            MemoryConfiguration memoryconfig = new MemoryConfiguration();
            TeamSpeakConfiguration teamspeakconfig=new TeamSpeakConfiguration();
            StyleConfiguration styleconfig = new StyleConfiguration();
            config.networkConfig = networkcon;
            config.clockConfig = clockcon;
            config.cpuConfig = cpuconfig;
            config.memoryConfig = memoryconfig;
            config.tsconfig = teamspeakconfig;
            config.styleconig = styleconfig;
            return config;
        }
    }
}
