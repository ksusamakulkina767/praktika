using System;
class Program
{
    static void Main()
    {
        // объявление переменных для хранения двух чисел
        int a;
        int b;

        // Ввод первого числа
        while (true)
        {
            Console.Write("Введите первое целое число: ");

            if (int.TryParse(Console.ReadLine(), out a)) // проверка, являеться ли введеное значение целым числом
            {
                break;
            }

            Console.WriteLine("Ошибка! Введите именно целое число.");
        }

        // Ввод второго числа
        while (true)
        {
            Console.Write("Введите второе целое число: ");

            if (int.TryParse(Console.ReadLine(), out b)) // проверка, является ли введённое значение целым числом
            {
                break;
            }

            Console.WriteLine("Ошибка! Введите именно целое число.");  // если введено неправильное значение, выводим сообщение об ошибке
        }

        int sum = a + b; // сложение двух введенных чисел

        Console.WriteLine($"Сумма чисел: {sum}");

        Console.ReadKey();
    }
}

