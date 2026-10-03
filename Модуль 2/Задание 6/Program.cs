using System;
using System.Collections.Generic;
class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
   public double AverageGrade { get; set; }

    // Конструктор класса для создания объекта
    public Student(string firstName, string lastName, int age, double averageGrade)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        AverageGrade = averageGrade;
    }

    // Вывод информации о студенте
    public void PrintInfo()
    {
        Console.WriteLine($"Студент: {FirstName} {LastName} | Возраст: {Age} лет | Средний балл: {AverageGrade:F1}");
    }
}

class Program
{
    static void Main()
    {
        // Экземпляр 
        Student student1 = new Student("Иван", "Иванов", 20, 4.5);

        // Экземпляр 
        Student student2 = new Student("Анна", "Петрова", 19, 4.9);

        // Экземпляр 
        Student student3 = new Student("Алексей", "Сидоров", 21, 3.8);

        // Список объектов
        List<Student> students = new List<Student> { student1, student2, student3 };
        Console.WriteLine("Список студентов");

        // Цикл перебора элементов списка
        foreach (Student student in students)
        {
            student.PrintInfo();
        }
    }
}

