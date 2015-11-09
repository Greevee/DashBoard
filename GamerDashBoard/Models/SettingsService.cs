using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RainbowDashBoard.Models.Configuration;


namespace RainbowDashBoard.Models
{
    class SettingsService : ISettingsService
    {
        Configuration.Configuration config;

        public Configuration.Configuration getConfig()
        {
            throw new NotImplementedException();
        }

        public SettingsService()
        {
            config = new Configuration.Configuration();
        }
    }
}
