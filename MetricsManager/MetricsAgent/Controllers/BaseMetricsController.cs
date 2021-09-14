using MetricsAgent.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Базовый абстрактный контроллер
    /// </summary>
    /// <typeparam name="TRepo">Репозиторий</typeparam>
    /// <typeparam name="TMetric">Тип метрик</typeparam>
    public abstract class BaseMetricsController<TRepo, TMetric> : Controller where TRepo : IRepository<TMetric> where TMetric : class
    {
        public readonly ILogger<BaseMetricsController<TRepo, TMetric>> _logger;
        public readonly TRepo _repository;

        public BaseMetricsController(ILogger<BaseMetricsController<TRepo, TMetric>> logger, TRepo repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Получение выдержки из БД за указанный период
        /// </summary>
        /// <param name="fromTime">Начало периода</param>
        /// <param name="toTime">Конец периода</param>
        /// <returns>Найденные результаты и флаг выполнения</returns>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public virtual IActionResult GetByTimePeriod([FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            _logger.LogInformation($"Подключение к контроллеру {_logger.GetType().GetGenericArguments()[0].Name}");
            _logger.LogInformation($"Получение показателей за период: {fromTime}, {toTime}");
            var result = _repository.GetByTimePeriod(fromTime, toTime);
            if (result is null)
            {
                _logger.LogInformation("Ничего не найдено");
                return NotFound();
            }
            _logger.LogInformation("Запрос выполнен успешно");
            return Ok(result);
        }
    }
}