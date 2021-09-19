using MetricsAgent.Entities.Metrics;
using Microsoft.EntityFrameworkCore;

namespace MetricsAgent.DB
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Создаем базу данных, если её нет
            Database.EnsureCreated();
        }

        // ниже список таблиц
        public DbSet<CpuMetric> cpumetrics { get; set; }

        public DbSet<DotNetMetric> dotnetmetrics { get; set; }

        public DbSet<HddMetric> hddmetrics { get; set; }

        public DbSet<NetworkMetric> networkmetrics { get; set; }

        public DbSet<RamMetric> rammetrics { get; set; }
    }
}