using AutoMapper;

namespace MetricsManager.Interfaces
{
    /// <summary>
    /// Базовый интерфейс для маппера
    /// </summary>
    public interface IMetricMapper
    {
        /// <summary>
        /// Провайдер конфигурации для Mapper
        /// </summary>
        public IConfigurationProvider ConfigurationProvider { get; }

        /// <summary>
        /// Конвертирует объект в объект типа <typeparam name="T"/>
        /// </summary>
        /// <typeparam name="T">Тип, в который конвертируется объект</typeparam>
        /// <param name="source">Исходный объект</param>
        /// <returns>Результирующий объект</returns>
        T Map<T>(object source);
    }
}