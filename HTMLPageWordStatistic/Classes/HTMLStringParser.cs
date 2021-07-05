using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLPageWordStatistic.Classes
{
    /// <summary>
    /// Класс позволяет преобразовать строку слов HTML-страницы в словарь частоты встречаемости слов на сайте
    /// </summary>
    class HTMLStringParser
    {
        /// <summary>
        /// Строка слов HTML-страницы
        /// </summary>
        private string HTMLString;
        /// <summary>
        /// Список разделителей
        /// </summary>
        private char[] Splitters;
        /// <summary>
        /// Словарь частоты встречаемости слов на сайте
        /// </summary>
        private Dictionary<string, int> WordsCount;

        /// <summary>
        /// Создает новый экземпляр парсера
        /// </summary>
        /// <param name="htmlString">Строка слов HTML-страницы</param>
        public HTMLStringParser (string htmlString)
        {
            if (htmlString == null)
            {
                throw new ArgumentNullException("HTML текст пуст!", nameof(HTMLString));
            }
            HTMLString = htmlString;
            Splitters = new char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' };
        }

        /// <summary>
        /// Создает новый экземпляр парсера
        /// </summary>
        /// <param name="htmlString">Строка слов HTML-страницы</param>
        /// <param name="splitters">Список разделителей</param>
        public HTMLStringParser(string htmlString, char[] splitters)
        {
            if (htmlString == null)
            {
                throw new ArgumentNullException("HTML текст пуст!", nameof(HTMLString));
            }
            if (splitters == null)
            {
                throw new ArgumentNullException("Cписок разделителей пуст!", nameof(Splitters));
            }
            HTMLString = htmlString;
            Splitters = splitters;
        }

        /// <summary>
        /// Заменяет существующий список разделителей
        /// </summary>
        /// <param name="newSplitters">Новый список разделителей</param>
        public void ChangeSplitters (char[] newSplitters)
        {
            Splitters = newSplitters;
        }

        /// <summary>
        /// Заменяет существующую строку слов HTML-страницы
        /// </summary>
        /// <param name="newHTMLString">Строка слов HTML-страницы</param>
        public void ChangeHTMLString(string newHTMLString)
        {
            HTMLString = newHTMLString;
        }

        /// <summary>
        /// Позволяет получить словарь частоты встречаемости слов
        /// </summary>
        /// <returns>Словарь частоты встречаемости слов</returns>
        public Dictionary<string, int> GetWordsCount()
        {
            if (WordsCount == null)
            {
                throw new ArgumentNullException("Словарь количества слов пуст!", nameof(WordsCount));
            }
            return WordsCount;
        }

        /// <summary>
        /// Создает словарь частоты встречаемости слов по заданной строке слов HTML-страницы
        /// </summary>
        /// <returns>Строка слов HTML-страницы</returns>
        public Dictionary<string, int> CountWords()
        {
            WordsCount = new Dictionary<string, int>();
            foreach (var word in HTMLString.Split(Splitters))
            {
                if (word == "")
                {
                    continue;
                }

                WordsCount.TryGetValue(word.ToUpper(), out var count);
                WordsCount[word.ToUpper()] = count + 1;
            }
            return WordsCount;
        }
    }
}
