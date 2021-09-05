using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Less1Ex1
{
    public class TemperatureDB
    {
        private Dictionary<DateTime, int> _temperature;

        public TemperatureDB()
        {
            _temperature ??= new Dictionary<DateTime, int>();
        }

        /// <summary>
        /// Сохранение температуры в указанное время
        /// </summary>
        /// <param name="dateTime">Время сохранения</param>
        /// <param name="weatherForecast">Температура</param>
        public void Create(DateTime dateTime, int temperature)
        {
            // Т.к. для хранения использую словарь, который не может иметь одинаковые ключи,
            // то при нахождении записи с требуемым ключом, мы просто её обновим
            if (_temperature.ContainsKey(dateTime))
            {
                _temperature[dateTime] = temperature;
            }
            else
            {
                _temperature.Add(dateTime, temperature);
            }
        }

        /// <summary>
        /// Получение температуры за указанный промежуток времени
        /// </summary>
        /// <param name="dateTime">Время</param>
        /// <returns>Температура</returns>
        public List<WeatherForecast> Read(DateTime firstDateTime, DateTime lastDateTime)
        {
            return _temperature
                .Where(x => x.Key >= firstDateTime && x.Key <= lastDateTime)
                .OrderBy(y => y.Key)
                .Select(x => new WeatherForecast() { Datetime = x.Key, TemperatureC = x.Value })
                .ToList();
        }

        /// <summary>
        /// Вывод всех имеющихся записей о температуре
        /// </summary>
        /// <returns></returns>
        public List<WeatherForecast> ReadAll()
        {
            return _temperature
                .OrderBy(y => y.Key)
                .Select(x => new WeatherForecast() { Datetime = x.Key, TemperatureC = x.Value })
                .ToList();
        }

        /// <summary>
        /// Редактирование температуры в указанное время
        /// </summary>
        /// <param name="dateTime">Время</param>
        /// <param name="weatherForecast">Температура</param>
        public void Update(DateTime dateTime, int temperature)
        {
            if (_temperature.ContainsKey(dateTime))
            {
                _temperature[dateTime] = temperature;
            }
            else
            {
                _temperature.Add(dateTime, temperature);
            }
        }

        /// <summary>
        /// Удаление температуры за указанный промежуток времени
        /// </summary>
        /// <param name="firstDateTime">Начало промежутка времени</param>
        /// <param name="lastDateTime">Конец промежутка времени</param>
        public void Delete(DateTime firstDateTime, DateTime lastDateTime)
        {
            foreach (var item in _temperature)
            {
                if (item.Key >= firstDateTime && item.Key <= lastDateTime)
                {
                    _temperature.Remove(item.Key);
                }
            }
        }
    }
}