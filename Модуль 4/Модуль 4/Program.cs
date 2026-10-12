using System;
interface IFigure
{
    double Area();
    double Perimeter();
}
class Circle : IFigure
{
    // Радиус круга
    public double r;

    // Вычисление площади круга
    public double Area() { return 3.14 * r * r; } 
    // Вычисление периметра круга
    public double Perimeter() { return 2 * 3.14 * r; }
}

class Rectangle : IFigure
{
    public double a, b;

    // Вычисление площади
    public double Area() { return a * b; }
    // Вычисление периметра
    public double Perimeter() { return 2 * (a + b); }
}

class Triangle : IFigure
{
    public double a, b, c;

    // Вычисление площади
    public double Area() { return a * b / 2; }

    // Вычисление периметра
    public double Perimeter() { return a + b + c; }
}

class Program
{
    static void Main()
    {
        // Создание круга
        Circle c = new Circle();

        // Ввод радиуса
        Console.Write("Радиус: ");
        c.r = double.Parse(Console.ReadLine());

        // Вывод площади и периметра
        Console.WriteLine("Площадь: " + c.Area());
        Console.WriteLine("Периметр: " + c.Perimeter());

        // Создание прямоугольника
        Rectangle r = new Rectangle();

        // Ввод длины
        Console.Write("\nДлина: ");
        r.a = double.Parse(Console.ReadLine());

        // Ввод ширины
        Console.Write("Ширина: ");
        r.b = double.Parse(Console.ReadLine());

        // Вывод площади и периметра
        Console.WriteLine("Площадь: " + r.Area());
        Console.WriteLine("Периметр: " + r.Perimeter());

        // Создание треугольника
        Triangle t = new Triangle();

        // Ввод первой стороны
        Console.Write("\nСторона 1: ");
        t.a = double.Parse(Console.ReadLine());

        // Ввод второй стороны
        Console.Write("Сторона 2: ");
        t.b = double.Parse(Console.ReadLine());

        // Ввод третьей стороны
        Console.Write("Сторона 3: ");
        t.c = double.Parse(Console.ReadLine());

        // Вывод площади и периметра
        Console.WriteLine("Площадь: " + t.Area());
        Console.WriteLine("Периметр: " + t.Perimeter());
        Console.ReadKey();
    }
}

