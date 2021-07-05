using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;
using HTMLPageWordStatistic.Classes;

namespace HTMLPageWordStatistic
{
    class Program
    {
        static void Main(string[] args)
        {
            HTMLCodeDownloader downloader = new HTMLCodeDownloader("https://www.simbirsoft.com/");
            var htmlText = downloader.GetInnerText();
           
            HTMLStringParser parser = new HTMLStringParser(htmlText);
            var wordsCount = parser.CountWords(); 
            
            foreach (var str in wordsCount)
            {
                Console.WriteLine($"{str.Key}: {str.Value}");
            }
            Console.ReadLine();
        }
    }
}