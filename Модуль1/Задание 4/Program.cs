using System;

class Program
{
    static void Main()
    {
        Random random = new Random(); 

        // Создание массива
        int[] numbers = new int[15];

        Console.WriteLine("Массив из 15 случайных чисел создан.");
      

        // Заполнение массива
        for (int i = 0; i < numbers.Length; i++) // заполнение массива случайными числами
        {
            numbers[i] = random.Next(-20, 21);
        }

        Console.WriteLine("Массив заполнен.");
        Console.ReadLine();

        // Вывод массива
        Console.WriteLine("Массив:");

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }

        Console.WriteLine();
        Console.ReadLine();

        // Поиск положительных чисел
        int sum = 0; // переменная для хранения суммы положительных чисел
        int count = 0; // переменная для подсчёта количества положительных чисел

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > 0)
            {
                sum += numbers[i]; // добавление положительного числа к сумме
                count++; // увеличение количества положительных чисел на 1
            }
        }

        Console.WriteLine("Поиск положительных чисел завершён.");
     

        // Проверка наличия положительных чисел
        if (count > 0)
        {
            Console.WriteLine("Количество положительных чисел: " + count);
            Console.WriteLine("Сумма положительных чисел: " + sum);
            Console.ReadLine();

            // Вычисление среднего значения
            double average = (double)sum / count; // вычисление среднего значения

            Console.WriteLine("Среднее значение положительных чисел: " + average);
        }
        else
        {
            Console.WriteLine("Положительных чисел в массиве нет.");
        }

        Console.ReadLine();
    }
}

