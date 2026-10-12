using System;
interface IProduct
{
    // Метод определения стоимости товара
    double Price();

    // Метод определения остатка товара
    int Stock();
}

class Product : IProduct
{
    // Цена товара
    public double price;

    // Количество товара
    public int count;

    // Расчёт общей стоимости
    // Возвращает результат метода
    public double Price() { return price * count; }

    // Определение количества товара
    public int Stock() { return count; }
}

class Program
{
    static void Main()
    {
        // Создание товара
        Product p = new Product();

        // Ввод цены хлеба
        Console.Write("Цена хлеба: ");
        p.price = double.Parse(Console.ReadLine());

        // Ввод количества хлеба
        Console.Write("Количество: ");
        p.count = int.Parse(Console.ReadLine());

        // Вывод стоимости и остатка
        Console.WriteLine("Стоимость: " + p.Price());
        Console.WriteLine("Остаток: " + p.Stock());

        // Ввод цены молока
        Console.Write("\nЦена молока: ");
        p.price = double.Parse(Console.ReadLine());

        // Ввод количества молока
        Console.Write("Количество: ");
        p.count = int.Parse(Console.ReadLine());

        // Вывод стоимости и остатка
        Console.WriteLine("Стоимость: " + p.Price());
        Console.WriteLine("Остаток: " + p.Stock());

        // Ввод цены яблок
        Console.Write("\nЦена яблок: ");
        p.price = double.Parse(Console.ReadLine());

        // Ввод количества яблок
        Console.Write("Количество: ");
        p.count = int.Parse(Console.ReadLine());

        // Вывод стоимости и остатка
        Console.WriteLine("Стоимость: " + p.Price());
        Console.WriteLine("Остаток: " + p.Stock());

        Console.ReadKey();
    }
}