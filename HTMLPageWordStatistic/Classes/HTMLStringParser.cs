using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLPageWordStatistic.Classes
{
    class HTMLStringParser
    {
        private string HTMLString;
        private char[] Splitters;
        private Dictionary<string, int> WordsCount;

        public HTMLStringParser (string htmlString)
        {
            if (htmlString == null)
            {
                throw new ArgumentNullException("HTML текст пуст!", nameof(HTMLString));
            }
            HTMLString = htmlString;
            Splitters = new char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' };
        }

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

        public void ChangeSplitters (char[] newSplitters)
        {
            Splitters = newSplitters;
        }

        public void ChangeHTMLString(string newHTMLString)
        {
            HTMLString = newHTMLString;
        }

        public Dictionary<string, int> GetWordsCount()
        {
            if (WordsCount == null)
            {
                throw new ArgumentNullException("Словарь количества слов пуст!", nameof(WordsCount));
            }
            return WordsCount;
        }

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
