using System;
using System.Linq;
using System.Threading.Tasks;
using SmartRunwayApi.Data;
using SmartRunwayApi.Models;

namespace SmartRunwayApi.Services
{
    public class FlightSchedulerService:IFlightSchedulerService
    {
        private readonly IAirportRepository _airportRepository;

        public FlightSchedulerService(IAirportRepository airportRepository)
        {
            this._airportRepository = airportRepository;
        }

        /// <summary>
        /// Schedules a flight for landing by finding the availabilitiy of the runways and calculating the time for landing
        /// </summary>
        /// <param name="flight"> The flight to be taken off</param>
        /// <param name="buffer"> Buffer time between different operations</param>
        /// <param name="weatherOffset"> Delay due to weather conditions </param>
        /// <returns> Landing info </returns>
        public async Task<Landing> ScheduleLanding(Flight flight, int buffer, int weatherOffset)
        {
            var updatedFlightInfo = await _airportRepository.GetFlightById(flight.Id);

            if(updatedFlightInfo == null)
            {
                throw new IndexOutOfRangeException($"Flight id : {flight.Id} is not a valid flight id.");
            }

            var availableRunway = await FindAvailableRunway();
            var timeRequired = CalculateDuration(updatedFlightInfo.LandingDuration, buffer, weatherOffset);

            Landing landing = new Landing
            {
                FlightId = updatedFlightInfo.Id,
                IsFinished = false,
                RunwayId = availableRunway.Id,
                StartTime = availableRunway.NextAvailableTime,
            };

            await _airportRepository.AddLanding(landing);

            //updating the runway by adding the time required for landing to NextAvailable time.
            availableRunway.NextAvailableTime = availableRunway.NextAvailableTime.Add(timeRequired);
            availableRunway.Landings.Add(landing);
            await _airportRepository.UpdateRunway(availableRunway);

            await _airportRepository.SaveChangesAsync();

            return landing;

        }

        /// <summary>
        /// Schedules a flight for take off by finding the availabilitiy of the runways and calculating the time for takeoff
        /// </summary>
        /// <param name="flight"> The flight to be taken off</param>
        /// <param name="buffer"> Buffer time between different operations</param>
        /// <param name="weatherOffset"> Delay due to weather conditions </param>
        /// <returns> Take off info </returns>
        public async Task<TakeOff> ScheduleTakeOff(Flight flight, int buffer, int weatherOffset)
        {
            var updatedFlightInfo = await _airportRepository.GetFlightById(flight.Id);

            if (updatedFlightInfo == null)
            {
                throw new IndexOutOfRangeException($"Flight id : {flight.Id} is not a valid flight id.");
            }

            var availableRunway = await FindAvailableRunway();
            var timeRequired = CalculateDuration(updatedFlightInfo.LandingDuration, buffer, weatherOffset);

            TakeOff takeOff = new TakeOff
            {
                FlightId = updatedFlightInfo.Id,
                IsFinished = false,
                RunwayId = availableRunway.Id,
                StartTime = availableRunway.NextAvailableTime,
            };

            await _airportRepository.AddTakeOff(takeOff);

            //updating the runway by adding the time required for take off to NextAvailable time.
            availableRunway.NextAvailableTime = availableRunway.NextAvailableTime.Add(timeRequired);
            availableRunway.TakeOffs.Add(takeOff);
            await _airportRepository.UpdateRunway(availableRunway);

            await _airportRepository.SaveChangesAsync();

            return takeOff;
        }

        private async Task<Runway> FindAvailableRunway()
        {
            var runways = await _airportRepository.GetAllRunways();
            var availableRunway = runways.OrderBy(o => o.NextAvailableTime).FirstOrDefault();

            return availableRunway ?? runways.FirstOrDefault();
        }

        private TimeSpan CalculateDuration(TimeSpan timeRequiredByFlight, int buffer, int weatherOffset)
        {
            return new TimeSpan(timeRequiredByFlight.Hours,
                timeRequiredByFlight.Minutes + buffer + weatherOffset,
                timeRequiredByFlight.Seconds);
        }
    }
}