using System;

namespace Less1Ex1
{
    public class WeatherForecast
    {
        public DateTime Datetime { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}