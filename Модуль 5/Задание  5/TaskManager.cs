using System.Collections.Generic;

namespace Задание_3
{
    public class TaskManager
    {
        // Список для хранения текстов задач
        private List<string> tasks = new List<string>();

        // Возвращает все текущие задачи
        public List<string> GetTasks()
        {
            return tasks;
        }

        // Добавляет задачу в список (возвращает false, если текст пустой)
        public bool AddTask(string taskText)
        {
            // Если строка пустая или состоит только из пробелов — это ошибка
            if (string.IsNullOrWhiteSpace(taskText))
            {
                return false;
            }

            // Добавляем задачу, убирая лишние пробелы по краям
            tasks.Add(taskText.Trim());
            return true;
        }

        // Удаляет задачи по списку выбранных индексов
        public void DeleteTasks(List<int> indicesToRemove)
        {
            // Сортируем индексы от большего к меньшему, чтобы при удалении не сбился порядок
            indicesToRemove.Sort((a, b) => b.CompareTo(a));

            foreach (int index in indicesToRemove)
            {
                if (index >= 0 && index < tasks.Count)
                {
                    tasks.RemoveAt(index);
                }
            }
        }

        // Полная очистка списка задач
        public void Clear()
        {
            tasks.Clear();
        }
    }
}