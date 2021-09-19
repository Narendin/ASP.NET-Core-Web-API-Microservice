using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetricsAgent.Interfaces
{
    /// <summary>
    /// Базовый интерфейс контроллеров метрик
    /// </summary>
    /// <typeparam name="TDto">Используемый Dto</typeparam>
    public interface IMetricsController<TDto>
    {
        /// <summary>
        /// Получение данных за указанный период времени
        /// </summary>
        /// <param name="fromTime">Начало периода</param>
        /// <param name="toTime">Конец периода</param>
        /// <returns>Лист Dto метрик за указанный период</returns>
        Task<List<TDto>> GetByTimePeriod([FromRoute] DateTime fromTime, [FromRoute] DateTime toTime);

        /// <summary>
        /// Добавление нойо записи в БД
        /// </summary>
        /// <param name="request">Новые данные</param>
        /// <returns></returns>
        Task Create([FromBody] TDto request);

        /// <summary>
        /// Обновление данных в БД
        /// </summary>
        /// <param name="request">Обновленные данные</param>
        /// <returns></returns>
        Task Update([FromBody] TDto request);

        /// <summary>
        /// Удаление записи из БД
        /// </summary>
        /// <param name="request">Удаляемые данные</param>
        /// <returns></returns>
        Task Delete([FromBody] TDto request);
    }
}