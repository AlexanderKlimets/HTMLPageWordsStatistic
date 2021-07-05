using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLPageWordStatistic.Classes
{
    class HTMLCodeDownloader
    {
        private string PageURL;
        private HtmlAgilityPack.HtmlDocument HTMLCode;

        public HTMLCodeDownloader(string pageURL)
        {
            if (pageURL == null)
            {
                throw new ArgumentNullException("URL страницы пуст!", nameof(PageURL));
            }
            PageURL = pageURL;            
        }

        private void DownloadHTML()
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HTMLCode = htmlWeb.Load(PageURL);
        }
        
        public void ChangeURL(string newPageURL)
        {
            PageURL = newPageURL;
        }

        public HtmlAgilityPack.HtmlDocument GetHTMLCode()
        {   
            if (HTMLCode == null)
            {
                DownloadHTML();
            }
            return HTMLCode;
        }

        public string GetInnerText()
        {
            if (HTMLCode == null)
            {
                DownloadHTML();
            }
            return HTMLCode.DocumentNode.InnerText;           
        }
    }
}
