using MetricsManader.DB;
using MetricsManager.DB.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DB.Repositories
{
    public class SqLiteMetricRepository<T> : IDbRepository<T> where T : AgentInfo, new()
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
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        /// <inheritdoc/>
        public async Task AddAsync(T agent)
        {
            await _context.Set<T>().AddAsync(agent);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(T agent)
        {
            await Task.Run(() => _context.Set<T>().Update(agent));
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(T agent)
        {
            await Task.Run(() => _context.Set<T>().Remove(agent));
            await _context.SaveChangesAsync();
        }
    }
}