using System.Collections.Generic;
using System.IO;
using ConsoleRssReader.DataLayer;

namespace ConsoleRssReader.BusinessLayer.Services
{
    public class CommandsService
    {
        private readonly IRssManager _manager;
        //TODO: Add logger
        public CommandsService(IRssManager manager)
        {
            _manager = manager;
        }
        public string Pull()
        {
            List<string> listRss = _manager.ReadFromUrl();
            if (listRss == null)
            {
                return "The list of RSS feeds is empty!";
            }

            foreach (var rss in listRss)
            {
                //TODO:Exception Handler
                _manager.Download(rss);
            }
            return "Success!";
        }

        public List<string> List()
        {
            List<string> rssItemsInfo = new List<string>();
            FileInfo[] files = _manager.ReadFromLocal();
            RssHandlerService rssHandler = new RssHandlerService();
            foreach (var file in files)
            {
                //TODO: Exception Handler
                rssItemsInfo.Add(rssHandler.Handling(file)); 
            }
            return rssItemsInfo;
        }

        public string Remove()
        {
            //TODO: Exception Handler
            _manager.ClearLocal();
            return "All downloaded tapes are deleted.";
        }

        public void Exit()
        {
            //TODO: Write this func
        }
    }
}