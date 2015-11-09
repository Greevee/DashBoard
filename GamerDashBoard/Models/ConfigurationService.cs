using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RainbowDashBoard.Models.Configuration;
using System.IO;

namespace RainbowDashBoard.Models
{
    class ConfigurationService : IConfigurationService
    {
        Configuration.Configuration config;

        public Configuration.Configuration getConfig()
        {
            throw new NotImplementedException();
        }

        public ConfigurationService()
        {
            string fileName = @"Config/Config.xml";
            if (File.Exists(fileName))
            {
                Console.WriteLine("File does exist.");
            }
            else{
                Console.WriteLine("File does not exist.");
                TextWriter tw = new StreamWriter(fileName, true);
                tw.WriteLine("The next line!");
                tw.Close();
            }
               
            config = new Configuration.Configuration();
        }
    }
}
