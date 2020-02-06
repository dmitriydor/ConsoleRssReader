using System;
using System.Collections.Generic;
using System.IO;
using ConsoleRssReader.DataLayer;
using ConsoleRssReader.DataLayer.Types.Exceptions;
using Microsoft.Extensions.Logging;
namespace ConsoleRssReader.BusinessLayer.Services
{
    public class CommandsService
    {
        private readonly IRssManager _manager;
        private readonly ILogger _logger;
        private readonly IHandler _handler;
        public CommandsService(IRssManager manager, ILogger logger,IHandler handler)
        {
            _manager = manager;
            _logger = logger;
            _handler = handler;
        }
        public string Pull()
        {
            List<string> listRss = _manager.ReadFromUrl();
            if (listRss == null)
            {
                _logger.LogInformation("the list of RSS feeds is empty");
                return "The list of RSS feeds is empty!";
            }

            foreach (var rss in listRss)
            {
                try
                {
                    _manager.Download(rss);
                }
                catch (Exception e)
                {
                    _logger.LogError(e,"There was an error loading");
                }
                
            }
            return "Success!";
        }

        public List<List<string>> List()
        {
            List<List<string>> rssItemsInfo = new List<List<string>>();
            try
            {
                FileInfo[] files = _manager.ReadFromLocal();
                foreach (var file in files)
                {
                    var resultHandling = _handler.Handling(file);
                    rssItemsInfo.Add(resultHandling);
                }
            }
            catch (DirectoryNotFoundException e)
            {
                _logger.LogError(e, e.Message);
            }
            catch (ArgumentNullException e)
            {
                _logger.LogError(e, e.Message);
            }
            catch (UrlAlreadyExistsException e)
            {
                _logger.LogError(e, e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e,e.Message);
            }
            return rssItemsInfo;
        }
        
        public string Remove()
        {
            try
            {
                _manager.ClearLocal();
            }
            catch (DirectoryNotFoundException e)
            {
                _logger.LogError(e,e.Message);
            }
            return "All downloaded tapes are deleted.";
        }

        public string Add(string url)
        {
            try
            {
                _manager.AddUrl(url);
            }
            catch (Exception e)
            {
                _logger.LogError(e,e.Message);
            }
            return "Success!";
        }
    }
}