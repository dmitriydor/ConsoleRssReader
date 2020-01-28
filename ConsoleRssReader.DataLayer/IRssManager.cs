using System.Collections.Generic;
using System.IO;

namespace ConsoleRssReader.DataLayer
{
    public interface IRssManager
    {
        FileInfo[] ReadFromLocal();
        List<string> ReadFromUrl();
        void ClearLocal();
        void AddUrl(string url);
        void Download(string url);
    }
}