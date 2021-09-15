using MetricsAgent.DB;
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
    public abstract class BaseMetricsController<TRepo, TMetric> : Controller, IMetricsController
        where TRepo : IRepository<TMetric>
        where TMetric : class
    {
        private readonly ILogger<BaseMetricsController<TRepo, TMetric>> _logger;
        private readonly TRepo _repository;
        private readonly Table _tableName;

        public BaseMetricsController(ILogger<BaseMetricsController<TRepo, TMetric>> logger, TRepo repository, Table tableName)
        {
            _logger = logger;
            _repository = repository;
            _tableName = tableName;
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
            _logger.LogInformation($"Получение показателей за период: с {fromTime} по {toTime}");
            _repository.TableName = _tableName;
            var result = _repository.GetByTimePeriod(fromTime, toTime);
            if (result is null)
            {
                _logger.LogInformation("Ничего не найдено");
                return NotFound();
            }
            _logger.LogInformation("Запрос выполнен успешно");
            return Ok(result);
        }

        [HttpPost("create/time/{time}/value/{value}")]
        public virtual IActionResult Create([FromRoute] DateTime time, [FromRoute] int value)
        {
            throw new NotImplementedException();
        }

        [HttpPut("update/time/{time}/lastValue/{lastValue}/newValue/{newValue}")]
        public virtual IActionResult Update([FromRoute] DateTime time, [FromRoute] int lastValue, [FromRoute] int newValue)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("create/time/{time}/value/{value}")]
        public virtual IActionResult Delete([FromRoute] DateTime time, [FromRoute] int value)
        {
            throw new NotImplementedException();
        }
    }
}