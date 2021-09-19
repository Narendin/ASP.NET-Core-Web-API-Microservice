using MetricsAgent.Entities.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DB.Interfaces
{
    /// <summary>
    /// Базовый интерфейс репозиториев
    /// </summary>
    /// <typeparam name="TMetric">Тип метрики</typeparam>
    public interface IDbRepository<TMetric> where TMetric : BaseMetric
    {
        /// <summary>
        /// Метод получения данных из БД
        /// </summary>
        /// <returns>IQueryable список</returns>
        IQueryable<TMetric> GetAll();

        /// <summary>
        /// Метод асинхронного добавления записи в БД
        /// </summary>
        /// <param name="metrics">Добавляемые метрики</param>
        /// <returns></returns>
        Task AddAsync(TMetric metrics);

        /// <summary>
        /// Метод асинхронного обновления записей в БД
        /// </summary>
        /// <param name="metrics">Обновляемые метрики</param>
        /// <returns></returns>
        Task UpdateAsync(TMetric metrics);

        /// <summary>
        /// Метод асинхронного удаления записи из БД
        /// </summary>
        /// <param name="metrics">Удаляемые метрики</param>
        /// <returns></returns>
        Task DeleteAsync(TMetric metrics);
    }
}