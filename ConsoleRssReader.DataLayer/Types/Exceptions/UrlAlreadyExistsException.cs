using System;

namespace ConsoleRssReader.DataLayer.Types.Exceptions
{
    public class UrlAlreadyExistsException : Exception
    {
        public UrlAlreadyExistsException() : base(message:"Такой URL уже существует")
        {
        }
    }
}