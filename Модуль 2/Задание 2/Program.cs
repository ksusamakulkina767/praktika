using System;
class Shape
{
    public virtual double Area() { return 0; } // метод
    public virtual double Perimeter() { return 0; }
}
class Circle : Shape
{
    public double r;
    public override double Area() { return Math.PI * r * r; }    // Вычисление площади круга
    public override double Perimeter() { return 2 * Math.PI * r; }     // Вычисление периметра круга
}
class Rectangle : Shape
{
    public double a, b;
    public override double Area() { return a * b; }     // Вычисление площади прямоугольника
    public override double Perimeter() { return 2 * (a + b); }   // Вычисление периметра прямоугольника
}
class Program
{
    static void Main()
    {
        Circle c = new Circle();         // Создание объекта круга
        Rectangle r = new Rectangle(); // Создание объекта прямоугольника

        Console.Write("Радиус: ");
        c.r = double.Parse(Console.ReadLine());

        Console.Write("Длина: ");
        r.a = double.Parse(Console.ReadLine());

        Console.Write("Ширина: ");
        r.b = double.Parse(Console.ReadLine());

        Console.WriteLine("Круг: " + c.Area() + " " + c.Perimeter());      // Вывод площади и периметра круга

        Console.WriteLine("Прямоугольник: " + r.Area() + " " + r.Perimeter());     // Вывод площади и периметра прямоугольника
    }
}

