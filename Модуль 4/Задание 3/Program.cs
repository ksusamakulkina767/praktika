using System;
interface IStudent
{
    // Метод определения среднего балла
    double Average();

    // Метод получения курса
    int Course();
}
class Student : IStudent
{
    // Три оценки студента
    public double a, b, c;

    // Курс студента
    public int course;

    // Расчёт среднего балла
    public double Average() { return (a + b + c) / 3; }

    // Получение курса
    public int Course() { return course; }
}

class Program
{
    // Метод ввода данных студента, записывает его курс, счтиывает оценки и возвращает заполненный объект
    static Student Input(int course)
    {
        // Создание студента
        Student s = new Student();

        // Запись курса
        s.course = course;

        // Вывод номера курса
        Console.WriteLine("\n" + course + " курс");

        // Ввод трёх оценок
        Console.Write("Оценки: ");
        string[] inputs = Console.ReadLine().Split(); 
        s.a = double.Parse(inputs[0]);
        s.b = double.Parse(inputs[1]);
        s.c = double.Parse(inputs[2]);

        // Вывод среднего балла
        Console.WriteLine("Средний балл: " + s.Average());

        // Возвращение данных студента
        return s;
    }

    static void Main()
    {
        // Ввод студента 1 курса
        Student s1 = Input(1);

        // Ввод студента 2 курса
        Student s2 = Input(2);

        // Ввод студента 3 курса
        Student s3 = Input(3);

        // Ожидание нажатия Enter
        Console.ReadLine();
    }
}

