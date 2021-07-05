using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLPageWordStatistic.Classes
{
    /// <summary>
    /// Класс позволяет при возникновении ошибки сохранить информацию о ней в текстовый файл
    /// </summary>
    class Saver
    {
        /// <summary>
        /// Путь к файлу логирования
        /// </summary>
        private string FILE_PATH;

        /// <summary>
        /// Создает новый экземляр логера
        /// </summary>
        public Saver()
        {           
            FILE_PATH = "errorsLog.txt";
        }

        /// <summary>
        /// Создает новый экземляр логера с заданным путем файла логов
        /// </summary>
        /// <param name="newFilePath">Путь файла логов</param>
        public Saver (string newFilePath)
        {
            if (newFilePath == null)
            {
                throw new ArgumentNullException("Имя файл логирования пусто!", nameof(FILE_PATH));
            }
            FILE_PATH = newFilePath;
        }

        /// <summary>
        /// Сохраняет данные ошибки в файл логов
        /// </summary>
        /// <param name="e">Экземпляр ошибки</param>
        public void ExceptionSaved(Exception e)
        {
            using (StreamWriter sw = new StreamWriter(FILE_PATH, true, System.Text.Encoding.Default))
            {
                sw.WriteLine($"Date: {DateTime.Now}");
                sw.WriteLine($"Message: {e.Message}");
                sw.WriteLine($"Source: {e.Source}");
                sw.WriteLine($"Stack Trace: {e.StackTrace}");
                sw.WriteLine("___________________________________");
            }
        }
    }
}
