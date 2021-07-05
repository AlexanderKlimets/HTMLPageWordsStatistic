using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HTMLPageWordStatistic.Classes;

namespace HTMLPageWordStatistic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приветствуем вас в приложении HTMLPageWordStatistic!");
            while (true)
            {
                Console.WriteLine("Для выхода введите exit");
                Console.Write("Введите адрес сайта, с которым желаете продолжить работу: ");
                
                var url = Console.ReadLine();
                if (url == "exit")
                {
                    Environment.Exit(0);
                }
                var downloader = new HTMLCodeDownloader(url);//https://www.simbirsoft.com/
                try
                {
                    var htmlText = downloader.GetInnerText();
                    var parser = new HTMLStringParser(htmlText);
                    var wordsCount = parser.CountWords();


                    foreach (var str in wordsCount)
                    {
                        Console.WriteLine($"{str.Key}: {str.Value}");
                    }

                    
                }
                catch (UriFormatException e)
                {
                    Console.WriteLine("Невозможно получить текст по данному URL. Проверьте правильность URL.");
                    var saver = new Saver();
                    saver.ExceptionSaved(e);
                }
                catch(ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                    var saver = new Saver();
                    saver.ExceptionSaved(e);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    var saver = new Saver();
                    saver.ExceptionSaved(e);
                }

            }                       
        }
    }
}