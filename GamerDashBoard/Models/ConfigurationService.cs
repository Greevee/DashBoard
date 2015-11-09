using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RainbowDashBoard.Models.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace RainbowDashBoard.Models
{
    class ConfigurationService : IConfigurationService
    {
        Configuration.Configuration config;
        string fileName = @"Config/Config.xml";

        public Configuration.Configuration getConfig()
        {
            throw new NotImplementedException();
        }

        public ConfigurationService()
        {
            if (File.Exists(fileName))
            {
                //load config
                
            }
            else{
                //create new config  and write it
                config = new Configuration.Configuration();
                Configuration.Modul.NetworkConfiguration networkcon = new Configuration.Modul.NetworkConfiguration();
                networkcon.interfaceName = "test";
                config.networkConfig = networkcon;
                SerializeObject(config);
            }
               
           
        }
        public void SerializeObject<T>(T serializableObject)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }
    }
}
