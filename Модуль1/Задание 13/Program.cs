using System; 

class Program 
{
    static void Main() 
    {
        int number; 
        int sum = 0; // начальная сумма элементов массива
        int count = 0; // количество элементов массива

        // ввод заданного числа
        while (true)
        {
            Console.Write("Введите число: ");

            if (int.TryParse(Console.ReadLine(), out number) && number > 0) // проверяет, что пользователь ввёл положительное целое число
                break;

            Console.WriteLine("Ошибка! Введите положительное целое число.");
        }

        //  случайные чисела
        Random random = new Random();

        // создание массива максимального возможного размера
        int[] array = new int[number];

        // Заполнение массива случайными числами от 1 до 9
        while (sum + 1 <= number)
        {
            int value = random.Next(1, 10); // случайное число от 1 до 9

            // проверка возможности добавления элемента
            if (sum + value <= number)
            {
                array[count] = value; // запись случайного числа в массив
                sum += value; // увеличение суммы
                count++; // увеличение количества элементов
            }
        }

        // вывод элементов массива
        Console.WriteLine("\nЭлементы массива:");

        for (int i = 0; i < count; i++) // цикл перебора элементов массива от первого элемента до последнего заполненного
        {
            Console.Write(array[i] + " "); // вывод текущего элемента массива и пробела после него
        }

        // Вывод количества элементов
        Console.WriteLine("\nКоличество элементов: " + count);

        // Вывод суммы элементов
        Console.WriteLine("Сумма элементов: " + sum);
    }
}

