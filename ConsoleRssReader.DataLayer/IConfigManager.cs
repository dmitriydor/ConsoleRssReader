using ConsoleRssReader.DataLayer.Types;

namespace ConsoleRssReader.DataLayer
{
    public interface IConfigManager
    {
        Config Deserialization();
        void Serialization(Config config);
    }


}