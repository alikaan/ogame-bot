using BotDll;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BotConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bot = new OgameBot("alikaanturke@gmail.com", "mervus1234.");
            bot.Login();            
            Console.ReadLine();            
        }
    }
}
