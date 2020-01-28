using System.Collections.Generic;
using ConsoleRssReader.DataLayer;
using ConsoleRssReader.DataLayer.Types;

namespace ConsoleRssReader.Tests
{
    public class FakeConfigManager : IConfigManager
    {
        private Config Config { get; set; } = new Config(){LocalList = "config.json", UrlList = new List<string> {"hh.ru","habr.com"}};
        public Config Deserialization()
        {
            return Config;
        }

        public void Serialization(Config config)
        {
            Config = config;
        }
    }
}