using SmartRunwayApi.Models;
using System.Threading.Tasks;

namespace SmartRunwayApi.Services
{
    public interface IFlightSchedulerService
    {
        /// <summary>
        /// Schedules a flight for take off by finding the availabilitiy of the runways and calculating the time for takeoff
        /// </summary>
        /// <param name="flight"> The flight to be taken off</param>
        /// <param name="buffer"> Buffer time between different operations</param>
        /// <param name="weatherOffset"> Delay due to weather conditions </param>
        /// <returns> Take off info </returns>
        Task<TakeOff> ScheduleTakeOff(Flight flight, int buffer, int weatherOffset);

        /// <summary>
        /// Schedules a flight for landing by finding the availabilitiy of the runways and calculating the time for landing
        /// </summary>
        /// <param name="flight"> The flight to be taken off</param>
        /// <param name="buffer"> Buffer time between different operations</param>
        /// <param name="weatherOffset"> Delay due to weather conditions </param>
        /// <returns> Landing info </returns>
        Task<Landing> ScheduleLanding(Flight flight, int buffer, int weatherOffset);
    }
}