using Microsoft.EntityFrameworkCore;

namespace Модуль_6
{
    // Класс для работы с базой данных
    public class AppDbContext : DbContext
    {
        // Таблица сотрудников в базе
        // Создай в базе данных таблицу для сотрудников и назовать её Employees
        public DbSet<Employee> Employees => Set<Employee>();

        // Настройка подключения к базе
        // // Указываем, что нужно использовать SQL Server и даем адрес базы данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // База данных создастся автоматически в папке с программой
            optionsBuilder.UseSqlite("Data Source=employees.db");
        }
    }
}