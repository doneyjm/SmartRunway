using System;

namespace SmartRunwayApi.Services
{
    public class WeatherService : IWeatherService
    {
        /// <summary>
        /// Returns delay due to bad weather in minutes. If delay is more than 2 hrs it will return -1
        /// </summary>
        /// <returns> Delay in minutes and -1 if delay is more than 2 hrs</returns>
        public int GetDelayDueToBadWeather()
        {
            //Dummy code to return the delay
            Random random = new Random();
            var delay = random.Next(150);


            return delay > 120 ? -1 : delay;

        }
    }
}