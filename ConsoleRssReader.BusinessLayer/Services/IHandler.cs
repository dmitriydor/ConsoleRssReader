using System.Collections.Generic;
using System.IO;

namespace ConsoleRssReader.BusinessLayer.Services
{
    public interface IHandler
    {
        List<string> Handling(FileInfo file);
    }
}