using Microsoft.EntityFrameworkCore;

namespace Модуль_6
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // База данных создастся автоматически в папке с программой
            optionsBuilder.UseSqlite("Data Source=employees.db");
        }
    }
}