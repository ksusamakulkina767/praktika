using System;
using System.Collections.Generic;

// Делегат для выполнения действия с задачей
delegate void TaskAction(string task);

class Program
{
    // Метод вывода уведомления о задаче
    static void Notification(string task)
    {
        Console.WriteLine("Уведомление: " + task);
    }

    // Метод записи задачи в журнал
    static void Log(string task)
    {
        Console.WriteLine("Журнал: " + task);
    }

    static void Main()
    {
        // Список для хранения задач
        List<string> tasks = new List<string>();

        // Цикл работы программы
        while (true)
        {
            // Вывод меню
            Console.WriteLine("\n1 - Добавить задачу");
            Console.WriteLine("2 - Выполнить задачу");
            Console.WriteLine("3 - Показать задачи");
            Console.WriteLine("0 - Выход");

            // Ввод выбора пользователя
            string choice = Console.ReadLine();

            // Выход из программы
            if (choice == "0")
                break;

            // Добавление задачи
            if (choice == "1")
            {
                // Запрос названия задачи
                Console.Write("Введите задачу: ");

                // Добавление задачи в список
                tasks.Add(Console.ReadLine());

                // Сообщение об успешном добавлении
                Console.WriteLine("Задача добавлена!");
            }

            // Выполнение задачи
            if (choice == "2")
            {
                // Запрос номера задачи
                Console.Write("Номер задачи: ");

                // Получение номера задачи
                int number = int.Parse(Console.ReadLine());

                // Выбор способа выполнения задачи
                Console.Write("1 - Уведомление, 2 - Журнал: ");
                string n = Console.ReadLine();

                // Создание переменной делегата
                TaskAction action;

                // Выбор метода для делегата
                if (n == "1")
                    action = Notification;
                else
                    action = Log;

                // Выполнение выбранного метода для задачи
                action(tasks[number - 1]);
            }

            // Показ всех задач
            if (choice == "3")
            {
                // Перебор всех задач в списке
                for (int i = 0; i < tasks.Count; i++)

                    // Вывод номера и названия задачи
                    Console.WriteLine((i + 1) + ". " + tasks[i]); // номер задачи, сама задача
            }
        }
    }
}

