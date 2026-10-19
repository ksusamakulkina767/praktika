namespace Модуль_6
{
    // Класс Сотрудник 
    public class Employee
    {
        // Номер сотрудника (главный ключ, уникальный)
        public int Id { get; set; }

        // ФИО сотрудника
        public string FullName { get; set; } = string.Empty;

        // Должность
        public string Position { get; set; } = string.Empty;

        // Зарплата
        public decimal Salary { get; set; }
    }
}