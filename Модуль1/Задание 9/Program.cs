using System;
class Program
{
    static void Main()
    {
        int k, a, b;

        // ввод количества элементов массива
        while (true)
        {
            Console.Write("Введите количество элементов K: ");

            if (int.TryParse(Console.ReadLine(), out k) && k > 0)
                break;

            Console.WriteLine("Ошибка! K должно быть положительным целым числом.");
        }
        // ввод нижней границы диапазона A
        Console.Write("Введите A: ");
        a = int.Parse(Console.ReadLine());

        // ввод верхней границы диапазона B
        while (true)
        {
            Console.Write("Введите B: ");

            if (int.TryParse(Console.ReadLine(), out b) && b > a)
                break;

            Console.WriteLine("Ошибка! B должно быть больше A.");
        }

        // создание массива из K элементов
        int[] array = new int[k];

        // случайные чисела
        Random random = new Random();

        // заполнение массива случайными числами из диапазона [A, B)
        for (int i = 0; i < k; i++)
        {
            array[i] = random.Next(a, b);
        }
        // выводим исходный массив
        Console.WriteLine("\nИсходный массив:");

        for (int i = 0; i < k; i++)
        {
            Console.Write(array[i] + " ");
        }

        // изначально считаем первый элемент минимальным и максимальным
        int minIndex = 0;
        int maxIndex = 0;

        // поиск индекса минимального и максимального элементов
        for (int i = 1; i < k; i++)
        {
            if (array[i] < array[minIndex])
            {
                minIndex = i;
            }

            if (array[i] > array[maxIndex])
            {
                maxIndex = i;
            }
        }

        // вывод найденного индекса
        Console.WriteLine("\n\nИндекс минимального элемента: " + minIndex);
        Console.WriteLine("Индекс максимального элемента: " + maxIndex);
  
        // определяем начало и конец диапазона
        int start = Math.Min(minIndex, maxIndex);
        int end = Math.Max(minIndex, maxIndex);

        // Ввывод элементы между минимальным и максимальным,включая сами минимальный и максимальный элементы
        Console.WriteLine("\nЭлементы между минимальным и максимальным:");

        for (int i = start; i <= end; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}

