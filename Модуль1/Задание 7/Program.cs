using System;
class Program
{
    static void Main()
    {
        // создание целочисленныого массива из 10 элементов
        int[] array = new int[10];

        // случайных чисел
        Random random = new Random();

        // заполнение массива случайными числами от -100 до 100
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-100, 101);
        }

        // вывод исходного массива
        Console.WriteLine("Исходный массив:");

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }

        // нахождение индекса максимального элемента
        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxIndex])
            {
                maxIndex = i;
            }
        }

        // вывод нового целого числа
        int number;
        while (true)
        {
            Console.Write("\n\nВведите целое число для замены максимального элемента: ");

            if (int.TryParse(Console.ReadLine(), out number))
            {
                break;
            }

            Console.WriteLine("Ошибка! Введите целое число.");
        }

        // замена максимального элемента введённым числом
        array[maxIndex] = number;

        // вывд изменёного массива
        Console.WriteLine("\nИзменённый массив:");

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();
    }
}

