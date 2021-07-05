using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace HTMLPageWordStatistic.Classes
{
    /// <summary>
    /// Класс позволяет загружать текст HTML-страницы по заданному URL, а также получить строку, содержащую все слова страницы
    /// </summary>
    class HTMLCodeDownloader
    {
        /// <summary>
        /// URL HTML-страницы
        /// </summary>
        private string PageURL;
        /// <summary>
        /// Код HTML-страницы
        /// </summary>
        private HtmlAgilityPack.HtmlDocument HTMLCode;

        /// <summary>
        /// Создает нового загрузчика
        /// </summary>
        /// <param name="pageURL">URL HTML-страницы</param>
        public HTMLCodeDownloader(string pageURL)
        {
            if (pageURL == null)
            {
                throw new ArgumentNullException("URL страницы пуст!", nameof(PageURL));
            }
            PageURL = pageURL;            
        }

        /// <summary>
        /// Загружает код HTML-страницы
        /// </summary>
        private void DownloadHTML()
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HTMLCode = htmlWeb.Load(PageURL);
        }

        /// <summary>
        /// Заменяет существующий URL HTML-страницы
        /// </summary>
        /// <param name="newPageURL">Новый URL HTML-страницы</param>
        public void ChangeURL(string newPageURL)
        {
            PageURL = newPageURL;
        }

        /// <summary>
        /// Возвращает код HTML-страницы
        /// </summary>
        /// <returns>Код HTML-страницы</returns>
        public HtmlAgilityPack.HtmlDocument GetHTMLCode()
        {   
            if (HTMLCode == null)
            {
                DownloadHTML();
            }
            return HTMLCode;
        }

        /// <summary>
        /// Возвращает строку слов HTML-страницы
        /// </summary>
        /// <returns>Строку слов HTML-страницы</returns>
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
