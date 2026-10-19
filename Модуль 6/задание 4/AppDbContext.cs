using Microsoft.EntityFrameworkCore;

namespace задание_4
{
    // Класс для работы с базой данных финансов
    public class AppDbContext : DbContext
    {
        // Таблица транзакций (доходы и расходы)
        public DbSet<TransactionItem> Transactions => Set<TransactionItem>();

        // Настройка подключения к базе
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // База данных сохранится в файле finances.db
            optionsBuilder.UseSqlite("Data Source=finances.db");
        }
    }
}