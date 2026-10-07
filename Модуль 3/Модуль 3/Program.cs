using System;
// Делегат, который хранит метод вычисления площади.
delegate double CalculateArea();
class Shape
{
    // Общий метод вычисления площади.
    // virtual позволяет дочерним классам создать свою версию метода.
    public virtual double Area()
    {
        return 0; // возвращает значение 0
    }
}
class Circle : Shape
{
    // Переменная для хранения радиуса круга
    public double R;
     
    // Метод вычисления площади круга.
    // override заменяет метод Area из класса Shape.
    public override double Area()
    {
        return Math.PI * R * R;
    }
}
class Rectangle : Shape
{
    public double A, B;

    // Вычисление площади прямоугольника
    public override double Area()
    {
        return A * B;
    }
}
class Triangle : Shape
{
    // A — основание, H — высота треугольника
    public double A, H;

    // Вычисление площади треугольника
    public override double Area()
    {
        return A * H / 2;
    }
}
class Program
{
    static void Main()
    {
        // Цикл позволяет несколько раз выбирать разные фигуры.
        // Цикл заканчивается, когда пользователь вводит 0.
        while (true)
        {
            // Вывод меню выбора фигуры
            Console.Write("1-Круг 2-Прямоугольник 3-Треугольник 0-Выход: ");

            // Получение выбора пользователя
            string n = Console.ReadLine();

            // Если введён 0, выход из цикла
            if (n == "0")
                break;

            // Создание делегата.
            // В него будет записан метод Area выбранной фигуры.
            // Создание переменной, которая пока ничего не будет содержать
            CalculateArea calc = null;

            // Если пользователь выбрал круг
            if (n == "1")
            {
                // Создание объекта круга
                Circle c = new Circle();

                // Ввод радиуса круга
                Console.Write("Радиус: ");
                c.R = double.Parse(Console.ReadLine());

                // Запись метода Area круга в делегат
                calc = c.Area;
            }

            // Если пользователь выбрал прямоугольник
            else if (n == "2")
            {
                // Создание объекта прямоугольника
                Rectangle r = new Rectangle();

                // Ввод первой стороны
                Console.Write("A: ");
                r.A = double.Parse(Console.ReadLine());

                // Ввод второй стороны
                Console.Write("B: ");
                r.B = double.Parse(Console.ReadLine());

                // Запись метода Area прямоугольника в делегат
                calc = r.Area;
            }
            // Если пользователь выбрал треугольник
            else if (n == "3")
            {
                // Создание объекта треугольника
                Triangle t = new Triangle();

                // Ввод основания
                Console.Write("Основание: ");
                t.A = double.Parse(Console.ReadLine());

                // Ввод высоты
                Console.Write("Высота: ");
                t.H = double.Parse(Console.ReadLine());

                // Запись метода Area треугольника в делегат
                calc = t.Area;
            }

            // Если пользователь ввёл неизвестный номер
            else
            {
                // Сообщение об ошибке
                Console.WriteLine("Ошибка!");

                // Переход к следующему повтору цикла
                continue;
            }

            // Вызов метода через делегат.
            // Выполняется Area той фигуры, которую выбрал пользователь.
            Console.WriteLine("Площадь: " + calc());
        }
    }
}

