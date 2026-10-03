using System;
class Author
{
    public string Name;       // Имя автора
    public int BirthYear;    // Год рождения
}
class Book
{
    public string Title;     // Название книги
    public int Year;         // Год выпуска
    public Author Author;    // Автор книги
}
class Program
{
    static void Main()
    {
        // Создание первого автора
        Author a1 = new Author { Name = "Лев Толстой", BirthYear = 1828 };

        // Создание второго автора
        Author a2 = new Author { Name = "Фёдор Достоевский", BirthYear = 1821 };

        // Создание первой книги и указание автора
        Book b1 = new Book { Title = "Война и мир", Year = 1869, Author = a1 };

        // Создание второй книги и указание автора
        Book b2 = new Book { Title = "Преступление и наказание", Year = 1866, Author = a2 };

        // Вывод информации о книгах
        Console.WriteLine(b1.Title + " - " + b1.Year + " - " + b1.Author.Name);
        Console.WriteLine(b2.Title + " - " + b2.Year + " - " + b2.Author.Name);
    }
}

