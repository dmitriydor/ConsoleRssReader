using System;

namespace ConsoleRssReader.PresenterLayer
{
    public class ConsoleDisplay:IDisplay
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}