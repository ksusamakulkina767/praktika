using System;
interface IRisunok
{
    // Объявление метода для рисования линии с координатами начальной и конечной точек
    void Line(int x1, int y1, int x2, int y2);

    // Объявление метода для рисования круга с заданным радиусом
    void Circle(double radius);

    // Объявление метода для рисования прямоугольника с заданной шириной и высотой
    void Rectangle(double width, double height);
}

class Canvas : IRisunok
{
    // Реализация метода рисования линии
    public void Line(int x1, int y1, int x2, int y2)
    {
        // Выводим в консоль текстовое сообщение с подстановкой координат 
        Console.WriteLine($"Нарисована линия от ({x1}, {y1}) до ({x2}, {y2})");
    }

    // Реализация метода рисования круга
    public void Circle(double radius)
    {
        // Выводим значение радиуса с округлением до 1 знака после запятой
        Console.WriteLine($"Нарисован круг радиусом {radius:F1}");
    }

    // Реализация метода рисования прямоугольника
    public void Rectangle(double width, double height)
    {
        // Выводим размеры прямоугольника с округлением до 1 знака после запятой
        Console.WriteLine($"Нарисован прямоугольник размером {width:F1}x{height:F1}");
    }
}

class Program
{
    static void Main()
    {
        // Создаем экземпляр класса Canvas для вызова методов рисования
        Canvas canvas = new Canvas();

        // Создаем объект Random для генерации случайных чисел
        Random rnd = new Random();

        // Генерация случайных значений для линии 
        int x1 = rnd.Next(0, 100); // Случайная координата X1 от 0 до 99
        int y1 = rnd.Next(0, 100); 
        int x2 = rnd.Next(0, 100); 
        int y2 = rnd.Next(0, 100);

        // Генерация случайных значений для круга и прямоугольника
        // Умножением и сложением задается нужный диапазон значений
        //Возвращает случайное дробное число от 0 включительно до 1, не включая 1
        double radius = rnd.NextDouble() * 50 + 1;  // Радиус от 1.0 до 51.0
        double width = rnd.NextDouble() * 100 + 1;   // Ширина от 1.0 до 101.0
        double height = rnd.NextDouble() * 100 + 1;  // Высота от 1.0 до 101.0

        //Вызов методов с полученными рандомными значениями
        canvas.Line(x1, y1, x2, y2);
        canvas.Circle(radius);
        canvas.Rectangle(width, height);

        Console.ReadLine();
    }
}

