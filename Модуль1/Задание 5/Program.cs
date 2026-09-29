using System;

class Program
{
    static void Main()
    {
        int number;

        // 1. Ввод числа с проверкой
        while (true)
        {
            Console.Write("Введите целое число больше 1: ");

            if (int.TryParse(Console.ReadLine(), out number) && number > 1) // Проверка, является ли введенное целое число больше 1
            {
                break;
            }

            Console.WriteLine("Ошибка! Введите целое число больше 1.");
        }

        Console.WriteLine("Число принято.");
      

        // 2. Проверка на простое число
        bool isPrime = true; // простое число

        for (int i = 2; i < number; i++) // проверка делителия числа от 2 до числа перед ним
        {
            if (number % i == 0) // проверка, делится ли число без остатка
            {
                isPrime = false;
                break;
            }
        }

        // 3. Вывод результата
        if (isPrime)
        {
            Console.WriteLine($"Число {number} является простым.");
        }
        else
        {
            Console.WriteLine($"Число {number} не является простым.");
        }

   
        Console.ReadLine();
    }
}

