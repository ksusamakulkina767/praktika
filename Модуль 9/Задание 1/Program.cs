using System;
using System.Collections.Generic;
using System.IO;

namespace SimpleStudentApp
{
    class Program
    {
        // Список для хранения всех студентов в оперативной памяти
        static List<Student> students = new List<Student>();

        // Имя файла, в который сохраняются данные
        static string file = "students.txt";

        static void Main()
        {
            // Устанавливаем кодировку UTF-8 для корректного отображения русского языка в консоли
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Проверяем, существует ли файл с данными на диске, 
            // чтобы программа не выдала ошибку при самом первом запускe (когда файла еще нет)
            if (File.Exists(file))
            {
                // Считываем абсолютно все строки из текстового файла в массив строк
                string[] lines = File.ReadAllLines(file);

                // Цикл проходит по массиву с шагом 3 (i += 3), потому что 
                // данные каждого студента в файле занимают ровно 3 строки (Id, Имя, Группа).
                // Условие (i + 2 < lines.Length) гарантирует, что нам хватит строк до конца файла
                for (int i = 0; i + 2 < lines.Length; i += 3)
                {
                    // Создаем объект студента и заполняем его данными из массива строк
                    students.Add(new Student
                    {
                        Id = int.Parse(lines[i]),     // Превращаем текст первой строки обратно в число (Id)
                        Name = lines[i + 1],           // Вторая строка — это имя студента
                        Group = lines[i + 2]          // Третья строка — это название группы
                    });
                }
            }

            while (true)
            {
                // Вывод пунктов меню на экран
                Console.WriteLine("\n1. Показать студентов");
                Console.WriteLine("2. Добавить студента");
                Console.WriteLine("3. Удалить студента");
                Console.WriteLine("4. Найти студента");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                string choice = Console.ReadLine();

                // Показать всех студентов
                if (choice == "1")
                {
                    foreach (Student s in students)
                        Console.WriteLine($"{s.Id}. {s.Name}, группа {s.Group}");
                }
                // Добавить нового студента
                else if (choice == "2")
                {
                    Student s = new Student();

                    // Автоматически назначаем ID: если список пустой, ставим 1, иначе берем ID последнего студента и прибавляем 1
                    s.Id = students.Count == 0 ? 1 : students[students.Count - 1].Id + 1;

                    Console.Write("Имя: ");
                    s.Name = Console.ReadLine();

                    Console.Write("Группа: ");
                    s.Group = Console.ReadLine();

                    students.Add(s);
                    Save();
                }
                // Удалить студента по ID
                else if (choice == "3")
                {
                    Console.Write("Введите ID: ");

                    // Безопасно проверяем, ввел ли пользователь число, удаляем студента с этим ID из списка и сохраняем изменения в файл
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        students.RemoveAll(s => s.Id == id);
                        Save();
                    }
                    // Поиск студента по имени
                    else if (choice == "4")
                        // Выполняем регистронезависимый поиск студентов по введенному имени (или его части) и выводим совпадения на экран
                        Console.Write("Введите имя: ");
                    string name = Console.ReadLine().ToLower();

                    foreach (Student s in students)
                    {
                        if (s.Name.ToLower().Contains(name))
                            Console.WriteLine($"{s.Id}. {s.Name}, группа {s.Group}");
                    
                // Выход из программы
                else if (choice == "0")
                {
                    Save();
                    break;
                }
            }
        }

        static void Save()
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (Student s in students)
                {
                    writer.WriteLine(s.Id);
                    writer.WriteLine(s.Name);
                    writer.WriteLine(s.Group);
                }
            }
        }
    }
}
}
}