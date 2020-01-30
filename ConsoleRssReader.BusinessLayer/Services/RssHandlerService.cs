﻿using System;
using System.IO;
using System.ServiceModel.Syndication;
using System.Xml;

namespace ConsoleRssReader.BusinessLayer.Services
{
    public class RssHandlerService
    {
        public string Handling(FileInfo file)
        {
            using StreamReader reader = new StreamReader(file.FullName);
            var xmlReader = XmlReader.Create(reader);
            var channel = SyndicationFeed.Load(xmlReader);
            string rssInfo = "";
            if (channel == null)
            {
                throw new NullReferenceException();
            }
            foreach (SyndicationItem rsi in channel.Items)
            {
                rssInfo = rsi.Title.Text + "\t" + rsi.PublishDate.Date.ToShortDateString() + "\t";
                foreach (SyndicationLink link in rsi.Links)
                {
                    rssInfo += link.Uri.ToString();
                }
            }
            xmlReader.Close();
            return rssInfo;
        }
    }
}