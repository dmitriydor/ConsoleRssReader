using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Syndication;
using System.Xml;

namespace ConsoleRssReader.BusinessLayer.Services
{
    public class RssHandlerService:IHandler
    {
        public List<string> Handling(FileInfo file)
        {
            using StreamReader reader = new StreamReader(file.FullName);
            var xmlReader = XmlReader.Create(reader);
            var channel = SyndicationFeed.Load(xmlReader);
            var rssInfo = "";
            List<string> listRss = new List<string>();
            foreach (SyndicationItem rsi in channel.Items)
            {
                rssInfo = rsi.Title.Text + "\t" + rsi.PublishDate.Date.ToShortDateString() + "\t";
                foreach (SyndicationLink link in rsi.Links)
                {
                    rssInfo += link.Uri.ToString();
                }
                listRss.Add(rssInfo);
            }
            xmlReader.Close();
            return listRss;
        }
    }
}