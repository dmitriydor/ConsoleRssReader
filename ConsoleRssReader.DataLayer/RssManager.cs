using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using ConsoleRssReader.DataLayer.Types;
using ConsoleRssReader.DataLayer.Types.Exceptions;

namespace ConsoleRssReader.DataLayer
{
    public class RssManager:IRssManager
    {
        private readonly IConfigManager _configManager;

        public RssManager(IConfigManager configManager)
        {
            _configManager = configManager;
        }
        public FileInfo [] ReadFromLocal()
        {
            string path = _configManager.Deserialization().LocalList;
            DirectoryInfo directory = new DirectoryInfo(path);
            if (!directory.Exists)
            {
                throw new DirectoryNotFoundException("Directory not found: " + path);
            }

            FileInfo[] files = directory.GetFiles();
            return files;
        }

        public List<string> ReadFromUrl()
        {
            return _configManager.Deserialization().UrlList;
        }

        public void ClearLocal()
        {
            string path = _configManager.Deserialization().LocalList;
            DirectoryInfo directory = new DirectoryInfo(path);
            if (!directory.Exists)
            {
                throw new DirectoryNotFoundException("Directory not found: " + path);
            }
            FileInfo[] files = directory.GetFiles();
            foreach (var file in files)
            {
                file.Delete();
            }
        }

        public void AddUrl(string url)
        {
            Config config = _configManager.Deserialization();
            if (config.UrlList.Contains(url))
            {
                throw new UrlAlreadyExistsException();
            }
            config.UrlList.Add(url);
            _configManager.Serialization(config);
        }

        public void Download(string url)
        {
            Config config = _configManager.Deserialization();
            WebClient downloader = new WebClient();
            string fileName = config.LocalList + url.Replace("/", "")
                                  .Replace(".", "")
                                  .Replace(":", "");
            downloader.DownloadFile(url,fileName);
        }
    }
}