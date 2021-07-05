using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

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
        }
    }
}