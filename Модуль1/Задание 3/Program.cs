using System;

class Program
{
    static void Main()
    {
        string text;

        while (true)
        {
            Console.Write("Введите строку: ");
            text = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(text))  // проверка, что строка не пустая и не состоит только из пробелов
            {
                break;
            }

            Console.WriteLine("Ошибка! Строка не должна быть пустой.");
        }
         
        char[] characters = text.ToCharArray(); // преобразование строки в массив символов
        Array.Reverse(characters);

        string reversedText = new string(characters);

        Console.WriteLine($"Строка в обратном порядке: {reversedText}");

        Console.ReadKey();
    }
}

