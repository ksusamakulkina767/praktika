using System; 
struct Train
{
    public string Destination; 
    public int Number;  
    public string Time;  
}
class Program
{
    static void Main()
    {
    
        Train[] trains = new Train[5];
         // ввод данных
        for (int i = 0; i < 5; i++)
        {
            // Вывод заголовка текущей итерации
            Console.WriteLine($"\nПоезд #{i + 1}");

            Console.Write("Пункт назначения: ");
            trains[i].Destination = Console.ReadLine(); 

            Console.Write("Номер поезда: ");
            trains[i].Number = Convert.ToInt32(Console.ReadLine());
            Console.Write("Время: ");
            trains[i].Time = Console.ReadLine();
        }

        //сортировка массив по возрастанию. 
        Array.Sort(trains, (a, b) => a.Number.CompareTo(b.Number));
        Console.WriteLine("\n Поезда по номерам");
        // Цикл foreach последовательно обходит все элементы отсортированного массива
        foreach (var t in trains)
            Console.WriteLine($"№{t.Number} {t.Destination} ({t.Time})");
        Console.Write("\nВведите номер для поиска: ");
        // Считывание и конвертация искомого номера поезда
        int search = Convert.ToInt32(Console.ReadLine());

        bool found = false;

        // Последовательный поиск по элементам массива
        foreach (var t in trains)
        {
            // Сравнение номера поезда в текущей структуре с искомым номером
            if (t.Number == search)
            {
                Console.WriteLine($"Найден: {t.Number} {t.Destination}, Время: {t.Time}");
                found = true; 
                break;
            }
        }

        if (!found) Console.WriteLine("Поезд не найден."); // вывести ошибку
        Array.Sort(trains, (a, b) =>               // сортировка
            a.Destination == b.Destination // одинаковое ли место у двух поездов
                ? a.Time.CompareTo(b.Time)
                : a.Destination.CompareTo(b.Destination)); // сравнивание, времени у второго и первого
        // если пункты назначения одинаковые, сравнить время

        Console.WriteLine("\n Поезда по назначениям и времени");
        // Вывод итогового отсортированного списка
        foreach (var t in trains)
            Console.WriteLine($"№{t.Number} {t.Destination} ({t.Time})");
    }
}

