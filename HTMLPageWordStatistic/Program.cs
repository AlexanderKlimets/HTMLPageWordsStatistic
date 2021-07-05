using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;

namespace HTMLPageWordStatistic
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {
                string htmlCode = client.DownloadString("https://www.simbirsoft.com/");
            }
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = htmlWeb.Load("https://www.simbirsoft.com/");
            var htmlText = document.DocumentNode.InnerText;
            var wordsCount = new Dictionary<string, int>();
            foreach (var word in htmlText.Split
               (' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t').Skip(1))
            {
                if (word == "")
                { 
                    continue; 
                }
                
                wordsCount.TryGetValue(word.ToUpper(), out var count);
                wordsCount[word.ToUpper()] = count + 1;
            }
            foreach (var str in wordsCount)
            {
                Console.WriteLine($"{str.Key}: {str.Value}");
            }
            Console.ReadLine();
        }
    }
}