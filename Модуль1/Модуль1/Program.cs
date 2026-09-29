using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        int n;

        while (true)
        {
            Console.Write("Введите целое неотрицательное число: ");
            n = int.Parse(Console.ReadLine()); // текст в обычное целое число

            if (n >= 0) // прверка, что число не является отрицательным
            {
                break;
            }

            Console.WriteLine("Ошибка: число не может быть отрицательным. Попробуйте еще раз.");
        }

        BigInteger factorial = 1; // переменная для вычисление факториала

        for (int i = 1; i <= n; i++) // вычисление факториала
        {
            factorial *= i;
        }

        Console.WriteLine($"{n}! = {factorial}"); // вывод вычисление факториала

        Console.ReadKey();
    }
}

