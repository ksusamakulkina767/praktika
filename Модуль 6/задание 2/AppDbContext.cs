using Microsoft.EntityFrameworkCore;

namespace Модуль_6
{
    // Класс для работы с базой данных задач
    public class AppDbContext : DbContext
    {
        // Таблица задач в базе данных
        public DbSet<TaskItem> Tasks => Set<TaskItem>();

        // Настройка подключения к базе
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // База данных для задач сохранится в файле tasks.db
            optionsBuilder.UseSqlite("Data Source=tasks.db");
        }
    }
}