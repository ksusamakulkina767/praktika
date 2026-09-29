using System;
class Program
{
    static void Main()
    {
        // переменная для хранения размера массива
        int n;

        // ввод размера массива с проверкой
        while (true)
        {

            Console.Write("Введите размер массива N: ");

            // проверяем, является ли введённое значение целым числом
            // и больше ли оно нуля
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                break;

            Console.WriteLine("Ошибка! N должно быть положительным числом.");
        }

        // создание массива из N элементов 
        double[] array = new double[n];

        // генерации случайных чисел
        Random random = new Random();

        // зполнение массива случайными числами
        for (int i = 0; i < n; i++)
        {
            // случайные числа от -100 до 100
            array[i] = random.Next(-100, 101);
        }
        Console.WriteLine("\nИсходный массив:");

        // перебор всех элементов массива
        for (int i = 0; i < n; i++)
        {
            // ввод текущего элемента массива
            Console.Write(array[i] + " ");
        }

        // нахождение максимального по модулю элемента
        double maxAbs = Math.Abs(array[0]);

        // перебор остальных элементов массива
        for (int i = 1; i < n; i++)
        {

            // если модуль больше найденного максимума,записываем его в maxAbs
            if (Math.Abs(array[i]) > maxAbs)
            {
                maxAbs = Math.Abs(array[i]);
            }
        }

        // нормируем каждый элемент массива
        // делим каждый элемент на максимальный по модулю
        for (int i = 0; i < n; i++)
        {
            array[i] /= maxAbs;
        }

        // вывод нормированного массива
        Console.WriteLine("\n\nНормированный массив:");

        // перебор всех элементов изменённого массива
        for (int i = 0; i < n; i++)
        {
            // вывод элемента с тремя знаками после запятой
            Console.Write($"{array[i]:F3} ");
        }

        // переход на новую строку
        Console.WriteLine();
    }
}

