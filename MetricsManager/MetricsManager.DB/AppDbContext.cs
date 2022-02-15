using MetricsManager.DB;
using Microsoft.EntityFrameworkCore;

namespace MetricsManader.DB
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Создаем базу данных, если её нет
            Database.EnsureCreated();
        }

        // ниже список таблиц
        public DbSet<AgentInfo> agents { get; set; }
    }
}