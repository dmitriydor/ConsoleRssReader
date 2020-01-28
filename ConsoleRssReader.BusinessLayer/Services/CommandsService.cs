using System;
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
                _manager.Download(rss);
            }
            return "Success!";
        }

        public List<string> List()
        {
            FileInfo[] files = _manager.ReadFromLocal();
            foreach (var file in files)
            {
                
            }
            return new List<string>();
        }

        public string Remove()
        {
            return "";
        }

        public void Exit()
        {
        }
    }
}