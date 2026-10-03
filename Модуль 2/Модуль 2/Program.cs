using System;
class Person
{
    public string Name { get; set; }     
    public int Age { get; set; }       
    public string Address { get; set; }  
}
class Program
{
    static void Main()
    {
        Console.Write("Сколько человек добавить: ");
        // Считываем строку с клавиатуры и преобразуем ее в целое число с помощью 
        int count = int.Parse(Console.ReadLine());

        // Создаем массив нужного размера для хранения объектов
        Person[] people = new Person[count];

        for (int i = 0; i < count; i++) // Это цикл, который повторяет действие несколько  
        {
            // Создаем новый экземпляр класса Person
            people[i] = new Person();

            Console.WriteLine($"\nЧеловек #{i + 1}:");

            Console.Write("Имя: ");
            people[i].Name = Console.ReadLine();

            // Считываем возраст
            Console.Write("Возраст: ");
            people[i].Age = int.Parse(Console.ReadLine());

            // Считываем адрес 
            Console.Write("Адрес: ");
            people[i].Address = Console.ReadLine();
        }

        Console.WriteLine("\n Список людей");

        // перебор всех объектов p из массива people
        foreach (var p in people)
        {
            Console.WriteLine($"Имя: {p.Name}, Возраст: {p.Age}, Адрес: {p.Address}");
        }
    }
}