using System;
interface IDrawable
{
    void Draw(); 
}
// Класс круга
class Circle : IDrawable
{
    public double Radius; // Радиус

    public void Draw() // Метод вывода
    {
        Console.WriteLine("Круг: радиус = " + Radius); // Вывод радиуса
    }
}
// Класс прямоугольника
class Rectangle : IDrawable
{
    public double Width; // Длина
    public double Height; // Ширина

    public void Draw() // Метод вывода
    {
        Console.WriteLine("Прямоугольник: длина = " + Width +
                          ", ширина = " + Height); // Вывод сторон
    }
}

// Класс треугольника
class Triangle : IDrawable
{
    public double A, B, C; // Стороны

    public void Draw() // Метод вывода
    {
        Console.WriteLine("Треугольник: стороны = " + A +
                          ", " + B + ", " + C); // Вывод сторон
    }
}

class Program
{
    static void Main() 
    {
        Random random = new Random(); 

        Circle circle = new Circle(); // Объект круга
        circle.Radius = random.Next(1, 11); // Случайный радиус

        Rectangle rectangle = new Rectangle(); // Объект прямоугольника
        rectangle.Width = random.Next(1, 11); // Случайная длина
        rectangle.Height = random.Next(1, 11); // Случайная ширина

        Triangle triangle = new Triangle(); // Объект треугольника
        triangle.A = random.Next(1, 11); // Случайная сторона
        triangle.B = random.Next(1, 11); // Случайная сторона
        triangle.C = random.Next(1, 11); // Случайная сторона

        IDrawable[] objects = { circle, rectangle, triangle }; // Массив объектов

        foreach (IDrawable obj in objects) // Перебор объектов
        {
            obj.Draw(); 
        }
    }
}

