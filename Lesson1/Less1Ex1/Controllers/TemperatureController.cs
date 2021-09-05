using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Less1Ex1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TemperatureController : ControllerBase
    {
        private readonly TemperatureDB _temperatureDB;

        public TemperatureController(TemperatureDB temperatureDB)
        {
            _temperatureDB = temperatureDB;
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            return Ok(_temperatureDB.ReadAll());
        }

        /// <summary>
        /// Сохранение температуры в указанное время
        /// </summary>
        /// <param name="stringDateTime">Время, в которое требуется сохранить температуру</param>
        /// <returns></returns>
        [HttpPost("{stringDateTime}")]
        public IActionResult Create([FromRoute] string stringDateTime)
        {
            var rand = new Random();
            bool isValid = DateTime.TryParse(stringDateTime, out DateTime dateTime);
            if (isValid)
            {
                _temperatureDB.Create(dateTime, rand.Next(-20, 55));
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Получение температуры за указанный промежуток времени
        /// </summary>
        /// <param name="stringStartTime">Начало промежутка</param>
        /// <param name="stringEndTime">Конец промежутка</param>
        /// <returns>Данные о температуре за указанный промежуток</returns>
        [HttpGet("{stringStartTime}-{stringEndTime}")]
        public IActionResult Read([FromRoute] string stringStartTime, [FromRoute] string stringEndTime)
        {
            var rand = new Random();
            bool isValidStart = DateTime.TryParse(stringStartTime, out DateTime startDateTime);
            bool isValidEnd = DateTime.TryParse(stringEndTime, out DateTime startEndTime);
            if (isValidStart && isValidEnd)
            {
                return Ok(_temperatureDB.Read(startDateTime, startEndTime));
            }
            return BadRequest();
        }

        /// <summary>
        /// Обновление данных о температуре в указанный промежуток
        /// </summary>
        /// <param name="stringDateTime">Дата и время, когда надо обновить данные</param>
        /// <param name="newValue">Новое значение температуры</param>
        /// <returns></returns>
        [HttpPut("{stringDateTime}/{newValue}")]
        public IActionResult Update([FromRoute] string stringDateTime, [FromRoute] string newValue)
        {
            bool isDateTimeValid = DateTime.TryParse(stringDateTime, out DateTime dateTime);
            bool isValueValid = int.TryParse(newValue, out int newTemperature);
            if (isDateTimeValid && isValueValid)
            {
                // По факту методы Create и Update в классе TemperatureDB идентичны.
                // Поэтому тут и вызываю метод Create.
                // Сам метод Update пока не удаляю, ибо пока не понимаю, можно ли так делать или надо строго разграничивать логику.
                _temperatureDB.Create(dateTime, newTemperature);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{stringStartTime}-{stringEndTime}")]
        public IActionResult Delete([FromRoute] string stringStartTime, [FromRoute] string stringEndTime)
        {
            bool isValidStart = DateTime.TryParse(stringStartTime, out DateTime startDateTime);
            bool isValidEnd = DateTime.TryParse(stringEndTime, out DateTime startEndTime);
            if (isValidStart && isValidEnd)
            {
                _temperatureDB.Delete(startDateTime, startEndTime);
                return Ok();
            }
            return BadRequest();
        }
    }
}