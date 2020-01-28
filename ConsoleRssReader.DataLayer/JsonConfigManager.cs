using System.IO;
using System.Runtime.Serialization.Json;
using ConsoleRssReader.DataLayer.Types;

namespace ConsoleRssReader.DataLayer
{
    public class JsonConfigManager:IConfigManager
    {
        public Config Deserialization()
        {
            Config config;
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Config));
            using (FileStream fs = new FileStream("config.json", FileMode.Open))
            {
                config = (Config) jsonSerializer.ReadObject(fs);
            }

            return config;
        }

        public void Serialization(Config config)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Config));
            using (FileStream fs = new FileStream("config.json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(fs,config);
            }
        }
    }
}