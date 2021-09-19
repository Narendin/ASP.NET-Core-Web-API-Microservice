using MetricsAgent.DB.Interfaces;
using MetricsAgent.Entities.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DB.Repositories
{
    public class SqLiteMetricRepository<TMetric> : IDbRepository<TMetric> where TMetric : BaseMetric, new()
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        public SqLiteMetricRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IQueryable<TMetric> GetAll()
        {
            return _context.Set<TMetric>().AsQueryable();
        }

        /// <inheritdoc/>
        public async Task AddAsync(TMetric metrics)
        {
            await _context.Set<TMetric>().AddAsync(metrics);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(TMetric metrics)
        {
            await Task.Run(() => _context.Set<TMetric>().Update(metrics));
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(TMetric metrics)
        {
            await Task.Run(() => _context.Set<TMetric>().Remove(metrics));
            await _context.SaveChangesAsync();
        }
    }
}