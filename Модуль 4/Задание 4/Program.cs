using System;
using System.Collections.Generic;
interface IBook
{
    string Title { get; }              // название книги (только для чтения)
    bool IsAvailable();                // доступна ли книга сейчас
    void Checkout(string reader);      // выдать книгу читателю
}

class Book : IBook
{
    public string Title { get; }       // название
    private bool taken;                // поле класса, которое хранит: занята книга или нет.

    public Book(string title)          // конструктор: задаём название
    {
        Title = title;
    }

    public bool IsAvailable()          // доступна, если не взята
    {
        if (taken)
        {
            return false;              // взята — недоступна
        }
        return true;                   // свободна — доступна
    }

    public void Checkout(string reader) // выдать книгу
    {
        if (taken)                     // если уже занята
        {
            Console.WriteLine(Title + " занята");
        }
        else                           // иначе — выдаём
        {
            taken = true;              // помечаем как занятую
            Console.WriteLine(Title + " выдана: " + reader);
        }
    }
}

// Электронная книга — могут читать сразу до 3 человек
class EBook : IBook
{
    public string Title { get; }       // название
    private int readers;               // сколько сейчас читают

    public EBook(string title)         // конструктор
    {
        Title = title;
    }

    public bool IsAvailable()          // доступна, если читателей меньше 3
    {
        if (readers < 3)
        {
            return true;
        }
        return false;
    }

    public void Checkout(string reader) // выдать доступ к книге
    {
        if (readers < 3)               // если есть свободное место
        {
            readers = readers + 1;     // добавляем читателя
            Console.WriteLine(Title + " открыта: " + reader + " (" + readers + "/3)");
        }
        else                           // если лимит достигнут
        {
            Console.WriteLine(Title + ": лимит");
        }
    }
}
class Program
{
    static void Main()
    {
        // Создаём список книг 
        List<IBook> books = new()
        {
            new Book("Война и мир"),
            new EBook("Чистый код"),
            new EBook("Преступление и наказание")
        };

        Console.Write("Имя: ");                      // спрашиваем имя читателя
        string r = Console.ReadLine() ?? "";    // если пусто 

        while (true)                                 // бесконечный цикл меню
        {
            Console.WriteLine("\n Список книг ");    // заголовок

            // Показываем все книги с номерами и статусом
            for (int i = 0; i < books.Count; i++)
                Console.WriteLine($"{i + 1}. {books[i].Title} — {(books[i].IsAvailable() ? "доступно" : "недоступно")}");

            Console.Write("0 - выход, выбор: ");     // приглашение

            // выбирает один из двух вариантов в зависимости от условия
            // Читаем выбор. Если не число или 0 — выходим
            if (!int.TryParse(Console.ReadLine(), out int c) || c == 0) break;

            // Если номер в диапазоне — выдаём книгу
            // Обращение к книге по индексу.
            if (c >= 1 && c <= books.Count) books[c - 1].Checkout(r);
        }
    }
}

