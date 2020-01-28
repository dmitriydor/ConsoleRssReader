using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConsoleRssReader.DataLayer.Types
{
    [DataContract]
    public class Config
    {
        [DataMember]
        public List<string> UrlList;
        [DataMember]
        public string LocalList;
    }
}