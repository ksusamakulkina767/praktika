using System; 

class Program 
{
    // статический метод вычисления наибольшего общего делителя
    static int GCD(int a, int b)
    {

        while (b != 0)
        {
            int temp = b; // временное сохранение значения b
            b = a % b; // вычисление остатка от деления a на b
            a = temp; // присваивание a предыдущего значения b
        }

        return a; // возврат наибольшего общего делителя
    }

    static void Main() // главный метод программы
    {
        int numerator;   // объявление переменной для числителя
        int denominator; // объявление переменной для знаменателя

        // ввод неотрицательного числителя
        while (true)
        {
            Console.Write("Введите числитель: ");

            if (int.TryParse(Console.ReadLine(), out numerator) && numerator >= 0) // проверка правильности ввода числителя.
                break;

            Console.WriteLine("Ошибка! Числитель должен быть неотрицательным целым числом.");
        }

        // ввод положительного знаменателя
        while (true)
        {
            Console.Write("Введите знаменатель: ");

            if (int.TryParse(Console.ReadLine(), out denominator) && denominator > 0) // знаменатель введён правильно и является положительным числом
                break;

            Console.WriteLine("Ошибка! Знаменатель должен быть положительным целым числом.");
        }

        // вычисление наибольшего общего делителя числителя и знаменателя
        int gcd = GCD(numerator, denominator);

        // сокращение дроби
        numerator = numerator / gcd;
        denominator = denominator / gcd;

        // вывод сокращённой дроби
        Console.WriteLine("\nСокращённая дробь: " + numerator + "/" + denominator);
    }
}

