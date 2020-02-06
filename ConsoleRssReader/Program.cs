using System;
using ConsoleRssReader.BusinessLayer.Services;
using ConsoleRssReader.DataLayer;
using Microsoft.Extensions.Logging;

namespace ConsoleRssReader
{
    static class Program
    {
        static void Main(string[] args)
        {
            IDisplay display = new ConsoleDisplay();
            IHandler handler = new RssHandlerService();
            IConfigManager configManager = new JsonConfigManager();
            IRssManager rssManager = new RssManager(configManager);
            var loggerFactory = new LoggerFactory();
            CommandsService commands = new CommandsService(rssManager,loggerFactory.CreateLogger<CommandsService>(),handler);
            bool exit = true;
            Console.WriteLine("Введите help для просмотра доступных комманд.");
            do
            {
                string command = Console.ReadLine();
                string[] commandFragments = command.Split(" ");
                string result = "";
                switch (commandFragments[0])
                {
                    case "pull":
                        result = commands.Pull();
                        display.Display(result);
                        break;
                    case "list":
                        var list = commands.List();
                        foreach (var rss in list)
                        {
                            foreach (var article in rss)
                            {
                                display.Display(article);
                            }
                        }
                        break;
                    case "remove":
                        result = commands.Remove(); 
                        display.Display(result);
                        break;
                    case "exit": 
                        exit = false; 
                        break;
                    case "clear": 
                        Console.Clear(); 
                        break;
                    case "add":
                        result = commands.Add(commandFragments[1]);
                        display.Display(result);
                        break;
                    case "help":
                        Console.WriteLine("pull\tЧитает RSS ленты из файла настроек, скачивает их и сохраняет на локальный диск." +
                                          "\nlist\tЧитает скаченные локально RSS ленты и отображает их элементы." +
                                          "\nremove\tУдаляет все скаченные RSS ленты." +
                                          "\nadd\tДобавляет RSS ленту в список для загрузки." +
                                          "\nclear\tОчисщает консоль." +
                                          "\nexit\tВыйти из программы."); break;
                    default: Console.WriteLine("Error executing command."); break;
                }
            } while (exit);
        }
    }
}