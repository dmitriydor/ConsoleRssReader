using System;

namespace ConsoleRssReader
{
    public class ConsoleDisplay:IDisplay
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}