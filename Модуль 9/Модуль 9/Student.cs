namespace StudentManagerWpf.Models
{
    // Класс, описывающий модель данных одного студента
    public class Student
    {
        // Уникальный идентификатор студента (порядковый номер)
        public int Id { get; set; }

        // Полное имя (ФИО) студента
        public string FullName { get; set; }

        // Возраст студента
        public int Age { get; set; }

        // Учебная группа, в которой учится студент
        public string Group { get; set; }

        // Средний балл студента (от 1 до 10)
        public double Gpa { get; set; }
    }
}