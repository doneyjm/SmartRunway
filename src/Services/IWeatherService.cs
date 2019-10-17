namespace SmartRunwayApi.Services
{
    public interface IWeatherService
    {
        /// <summary>
        /// Returns delay due to bad weather in minutes. If delay is more than 2 hrs it will return -1
        /// </summary>
        /// <returns> Delay in minutes and -1 if delay is more than 2 hrs</returns>
        int GetDelayDueToBadWeather();
    }
}