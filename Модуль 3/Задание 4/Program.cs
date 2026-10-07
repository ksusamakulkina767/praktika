using System;
// Делегат для фильтрации данных
// Принимает строку и значение для поиска
// Возвращает true или false
delegate bool Filter(string text, string value);
class Program
{
    // Метод фильтрации по слову
    // Проверяет, есть ли введённое слово в строке
    static bool Word(string text, string value)
    {
        return text.Contains(value); // Проверить, есть ли value внутри text
    }
    // Метод фильтрации по дате
    // Проверяет, есть ли введённая дата в строке
    static bool Date(string text, string value)
    {
        return text.Contains(value);
    }

    static void Main()
    {
        // Массив с готовыми данными
        string[] data =
        {
            "Работа 01.10.2026",
            "Учёба 02.10.2026",
            "Отдых 03.10.2025",
            "Работа 05.10.2026"
        };

        while (true)
        {
            // Вывод списка данных
            Console.WriteLine("\nСписок:");

            // Перебор всех элементов массива
            foreach (string x in data)
                Console.WriteLine(x);

            // Вывод меню
            Console.WriteLine("\n1 - Слово");
            Console.WriteLine("2 - Дата");
            Console.WriteLine("0 - Выход");

            // Ввод выбора пользователя
            Console.Write("Выбор: ");
            string c = Console.ReadLine();

            // Если пользователь ввёл 0,
            // цикл прекращается и программа заканчивается
            if (c == "0")
                break;

            // Если выбрано 1 — используется Word, иначе — Date  
            Filter f = c == "1" ? Word : Date;

            // Ввод значения для поиска
            Console.Write("Введите значение: ");
            string v = Console.ReadLine();

            // Перебор всех элементов списка
            foreach (string x in data)
            {
                // Проверка элемента выбранным фильтром
                // Если найдено совпадение, строка выводится
                if (f(x, v))
                    Console.WriteLine(x);
            }
        }
    }
}

