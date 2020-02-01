using System.IO;

namespace ConsoleRssReader.BusinessLayer.Services
{
    public interface IHandler
    {
        string Handling(FileInfo file);
    }
}