using System.IO;

namespace Задание2
{
    public class FileManager
    {
        // Переменная для хранения пути к открытому или сохраняемому файлу
        private string filePath = "";

        // Возвращает текущий путь к файлу
        public string GetFilePath()
        {
            return filePath;
        }

        // Устанавливает новый путь к файлу
        public void SetFilePath(string path)
        {
            filePath = path;
        }

        // Открывает файл по переданному пути и читает из него весь текст
        public string OpenFile(string path)
        {
            filePath = path;
            return File.ReadAllText(filePath); // Чтение текста из файла
        }

        // Сохраняет текст в текущий файл
        public void SaveFile(string text)
        {
            // Проверяем, что путь к файлу задан, прежде чем записывать
            if (!string.IsNullOrEmpty(filePath))
            {
                File.WriteAllText(filePath, text); // Запись текста в файл
            }
        }

        // Сбрасывает сохраненный путь (очищает память о файле)
        public void Clear()
        {
            filePath = "";
        }
    }
}