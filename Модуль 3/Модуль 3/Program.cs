using System; 
delegate double CalculateArea(); // Делегат — переменная для хранения метода вычисления

class Shape 
{ 
    public virtual double GetArea() { return 0; } // Метод площади по умолчанию возвращает 0
} 
class Circle : Shape 
{ 
    public double R; 
    public Circle(double r) { R = r; } // Конструктор: записывает радиус
    public override double GetArea() { return 3.14 * R * R; } 
} 
class Rectangle : Shape 
{
    public double W, H; // Переменные для ширины и высоты
    public Rectangle(double w, double h) { W = w; H = h; } // Конструктор: записывает ширину и высоту
    public override double GetArea() { return W * H; } 
} 
class Triangle : Shape 
{ 
    public double B, H; // Переменные для основания и высоты
    public Triangle(double b, double h) { B = b; H = h; } // Конструктор: записывает основание и высоту
    public override double GetArea() { return 0.5 * B * H; } 
}
class Program 
{ 
    static void Main() 
    { 
        while (true) 
        { 
            Console.Write("\n1-Круг, 2-Прямоугольник, 3-Треугольник, 0-Выход: "); 
            string choice = Console.ReadLine(); // Считываем выбор пользователя в строку

            if (choice == "0") break; // Если введён 0 — прерываем цикл и выходим

            CalculateArea calc = null; // Создаём пустую переменную делегата

            if (choice == "1") // Если выбран круг
            { 
                Console.Write("Радиус: "); 
                double r = double.Parse(Console.ReadLine()); // Считываем и переводим радиус в число
                calc = new Circle(r).GetArea; 
            } 
            else if (choice == "2") // Если выбран прямоугольник
            { 
                Console.Write("Ширина: "); 
                double w = double.Parse(Console.ReadLine()); // Считываем ширину
                Console.Write("Высота: "); 
                double h = double.Parse(Console.ReadLine()); // Считываем высоту
                calc = new Rectangle(w, h).GetArea; // Создаём прямоугольник и сохраняем его метод в делегат
            } 
            else if (choice == "3") // Если выбран треугольник
            { 
                Console.Write("Основание: "); 
                double b = double.Parse(Console.ReadLine()); // Считываем основание
                Console.Write("Высота: "); 
                double h = double.Parse(Console.ReadLine()); // Считываем высоту
                calc = new Triangle(b, h).GetArea; // Создаём треугольник и сохраняем его метод в делегат
            } 
            if (calc != null) // Если метод был успешно записан в делегат
            { 
                Console.WriteLine("Площадь: " + calc()); 
            } 
            else 
            { 
                Console.WriteLine("Ошибка ввода!"); 
            } 
        } 
    } 
}

