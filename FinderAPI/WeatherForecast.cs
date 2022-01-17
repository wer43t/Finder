using System;

namespace FinderAPI
{
    public class WeatherForecast        //Обязательно исправить Класс не используется в проекте (Мясников)
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
