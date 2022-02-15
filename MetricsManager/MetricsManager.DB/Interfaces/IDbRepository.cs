using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DB.Interfaces
{
    /// <summary>
    /// Базовый интерфейс репозиториев
    /// </summary>
    /// <typeparam name="T">Тип метрики</typeparam>
    public interface IDbRepository<T> where T : AgentInfo
    {
        /// <summary>
        /// Метод получения данных из БД
        /// </summary>
        /// <returns>IQueryable список</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Метод асинхронного добавления записи в БД
        /// </summary>
        /// <param name="agent">Добавляемые метрики</param>
        /// <returns></returns>
        Task AddAsync(T agent);

        /// <summary>
        /// Метод асинхронного обновления записей в БД
        /// </summary>
        /// <param name="agent">Обновляемые метрики</param>
        /// <returns></returns>
        Task UpdateAsync(T agent);

        /// <summary>
        /// Метод асинхронного удаления записи из БД
        /// </summary>
        /// <param name="agent">Удаляемые метрики</param>
        /// <returns></returns>
        Task DeleteAsync(T agent);
    }
}