using System;
class Program
{
    static void Main()
    {
        int k;

        // ввод количества простых чисел
        while (true)
        {
            Console.Write("Введите количество простых чисел K: ");

            if (int.TryParse(Console.ReadLine(), out k) && k > 0)
                break;

            Console.WriteLine("Ошибка! K должно быть положительным целым числом.");
        }
        int count = 0;  // сколько простых чисел уже найдено
        int number = 2; // начнем проверку с числа 2

        Console.WriteLine("\nПервые " + k + " простых чисел:");

        // поиск простых числа, пока не найдём K штук
        while (count < k)
        {
            bool isPrime = true;
            // проверка, делится ли число на другие числа
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            // если число простое
            if (isPrime)
            {
                Console.Write(number + "\t");
                count++;

                // после каждых 10 чисел переходим на новую строку
                if (count % 10 == 0)
                {
                    Console.WriteLine();
                }
            }

            number++;
        }
        Console.WriteLine();
    }
}