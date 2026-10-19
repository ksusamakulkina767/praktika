using Microsoft.EntityFrameworkCore;

namespace задание_2
{
    // Класс для работы с базой данных библиотеки
    public class AppDbContext : DbContext
    {
        // Таблица книг в базе данных
        public DbSet<Book> Books => Set<Book>();

        // Настройка подключения к базе
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // База данных сохранится в файле library.db
            optionsBuilder.UseSqlite("Data Source=library.db");
        }
    }
}