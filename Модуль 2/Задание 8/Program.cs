using System;
abstract class Shape
{
    public abstract double Area();
    public abstract double Perimeter();
}
// Круг
class Circle : Shape
{
    public double r;
    public override double Area() => Math.PI * r * r;
    public override double Perimeter() => 2 * Math.PI * r;
}
// Прямоугольник
class Rectangle : Shape
{
    public double a, b;
    public override double Area() => a * b;
    public override double Perimeter() => 2 * (a + b);
}
// Треугольник
class Triangle : Shape
{
    public double a, b, c;
    public override double Perimeter() => a + b + c;
    public override double Area()
    {
        double p = Perimeter() / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
}

class Program
{
    static void Main()
    {
        // Ввод круга
        Circle c = new Circle();
        Console.Write("Радиус круга: ");
        c.r = Convert.ToDouble(Console.ReadLine());

        // Ввод прямоугольника
        Rectangle r = new Rectangle();
        Console.Write("Сторона A прямоугольника: ");
        r.a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Сторона B прямоугольника: ");
        r.b = Convert.ToDouble(Console.ReadLine());

        // Ввод треугольника
        Triangle t = new Triangle();
        Console.Write("Сторона A треугольника: ");
        t.a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Сторона B треугольника: ");
        t.b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Сторона C треугольника: ");
        t.c = Convert.ToDouble(Console.ReadLine());

        // Вывод результатов
        Console.WriteLine("\nРЕЗУЛЬТАТЫ");
        Console.WriteLine("Круг: S = " + c.Area() + ", P = " + c.Perimeter());
        Console.WriteLine("Прямоугольник: S = " + r.Area() + ", P = " + r.Perimeter());
        Console.WriteLine("Треугольник: S = " + t.Area() + ", P = " + t.Perimeter());
    }
}

