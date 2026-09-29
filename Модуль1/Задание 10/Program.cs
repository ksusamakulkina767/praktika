using System;

class Program
{
    static void Main()
    {
        int k;

        // ввод количества элементов массива
        while (true)
        {
            Console.Write("Введите количество элементов K: ");

            if (int.TryParse(Console.ReadLine(), out k) && k > 0)
                break;

            Console.WriteLine("Ошибка! K должно быть положительным целым числом.");
        }

        // создание символьнонго массива из K элементов
        char[] array = new char[k];

        // русский алфавит
        string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        // случайные чисела
        Random random = new Random();

        // заполнение первого массива случайными буквами
        for (int i = 0; i < k; i++)
        {
            array[i] = alphabet[random.Next(alphabet.Length)];
        }

        // строка с согласными буквами русского алфавита
        string consonants = "бвгджзйклмнпрстфхцчшщ";

        // создание второго массива максимального возможного размера
        char[] newArray = new char[k];

        // счётчик согласных букв
        int count = 0;

        // проверка каждый элемент первого массива
        for (int i = 0; i < k; i++)
        {
            // если буква является согласной
            if (consonants.Contains(array[i]))
            {
                // длбавление её во второй массив
                newArray[count] = array[i];
                count++;
            }
        }

        // вывод первого массива
        Console.WriteLine("\nПервый массив:");

        for (int i = 0; i < k; i++)
        {
            Console.Write(array[i] + " ");
        }

        // вывод второго массива
        Console.WriteLine("\n\nМассив согласных букв:");

        for (int i = 0; i < count; i++)
        {
            Console.Write(newArray[i] + " ");
        }

        Console.WriteLine();
    }
}

