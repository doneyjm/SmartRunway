using SmartRunwayApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRunwayApi.Data
{
    public interface IAirportRepository
    {
        /// <summary>
        /// Get all runways available in the airport
        /// </summary>
        /// <returns> Collection of Runways</returns>
        Task<IEnumerable<Runway>> GetAllRunways();

        /// <summary>
        /// Get a particular runway with it's id
        /// </summary>
        /// <param name="id"> Runway id</param>
        /// <returns> A Runway </returns>
        Task<Runway> GetRunwayById(int id);

        /// <summary>
        /// Get all registered flights in this airport
        /// </summary>
        /// <returns> Collection of flights</returns>
        Task<IEnumerable<Flight>> GetFlights();

        /// <summary>
        /// Get a particluar flight by it's id
        /// </summary>
        /// <param name="id"> Flight id</param>
        /// <returns> Flight </returns>
        Task<Flight> GetFlightById(int id);

        /// <summary>
        /// Add new landing info
        /// </summary>
        /// <param name="landing"> Landing info </param>
        /// <returns></returns>
        Task AddLanding(Landing landing);

        /// <summary>
        /// Add new take off info
        /// </summary>
        /// <param name="takeOff"> Take off info </param>
        /// <returns></returns>
        Task AddTakeOff(TakeOff takeOff);

        /// <summary>
        /// Updates a particluar take off info
        /// </summary>
        /// <param name="takeOff"> take off info </param>
        /// <returns></returns>
        Task UpdateTakeOff(TakeOff takeOff);

        /// <summary>
        /// Updates a particluar landing
        /// </summary>
        /// <param name="landing"> Landing info </param>
        /// <returns></returns>
        Task UpdateLanding(Landing landing);

        /// <summary>
        /// Update a runway
        /// </summary>
        /// <param name="runway">Runway info</param>
        /// <returns></returns>
        Task UpdateRunway(Runway runway);

        /// <summary>
        /// Save pending changes to database
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}