using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartRunwayApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRunwayApi.Data
{
    public class AirportRepository : IAirportRepository
    {
        private readonly AirportDbContext _airportDbContext;
        private readonly IMapper _mapper;

        public AirportRepository(AirportDbContext airportDbContext, IMapper mapper)
        {
            this._airportDbContext = airportDbContext;
            this._mapper = mapper;
        }

        /// <summary>
        /// Add new landing info
        /// </summary>
        /// <param name="landing"> Landing info </param>
        /// <returns></returns>
        public async Task AddLanding(Landing landing)
        {
            var landingEntity = _mapper.Map<Entities.Landing>(landing);
            await this._airportDbContext.Landings.AddAsync(landingEntity);
        }

        /// <summary>
        /// Add new take off info
        /// </summary>
        /// <param name="takeOff"> Take off info </param>
        /// <returns></returns>
        public async Task AddTakeOff(TakeOff takeOff)
        {
            var takeOffEntity = _mapper.Map<Entities.TakeOff>(takeOff);
            await this._airportDbContext.TakeOffs.AddAsync(takeOffEntity);
        }

        /// <summary>
        /// Updates a particluar landing
        /// </summary>
        /// <param name="landing"> Landing info </param>
        /// <returns></returns>
        public async Task UpdateLanding(Landing landing)
        {
            var landingEntity = _mapper.Map<Entities.Landing>(landing);
            _airportDbContext.Landings.Update(landingEntity);
        }

        /// <summary>
        /// Updates a particluar take off info
        /// </summary>
        /// <param name="takeOff"> take off info </param>
        /// <returns></returns>
        public async Task UpdateTakeOff(TakeOff takeOff)
        {
            var takeOffEntity = _mapper.Map<Entities.TakeOff>(takeOff);
            _airportDbContext.TakeOffs.Update(takeOffEntity);
        }

        /// <summary>
        /// Get all runways available in the airport
        /// </summary>
        /// <returns> Collection of Runways</returns>
        public async Task<IEnumerable<Runway>> GetAllRunways()
        {
            var runways = await _airportDbContext.Runways.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<Runway>>(runways);
        }

        /// <summary>
        /// Get a particluar flight by it's id
        /// </summary>
        /// <param name="id"> Flight id</param>
        /// <returns> Flight </returns>
        public async Task<Flight> GetFlightById(int id)
        {
            var flight = await _airportDbContext.Flights.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Flight>(flight);
        }

        /// <summary>
        /// Get all registered flights in this airport
        /// </summary>
        /// <returns> Collection of flights</returns>
        public async Task<IEnumerable<Flight>> GetFlights()
        {
            var flights = await _airportDbContext.Flights.ToListAsync();
            return _mapper.Map<IEnumerable<Flight>>(flights);
        }

        /// <summary>
        /// Get a particular runway with it's id
        /// </summary>
        /// <param name="id"> Runway id</param>
        /// <returns> A Runway </returns>
        public async Task<Runway> GetRunwayById(int id)
        {
            var runway = await _airportDbContext.Runways.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Runway>(runway);
        }

        /// <summary>
        /// Update a runway
        /// </summary>
        /// <param name="runway">Runway info</param>
        /// <returns></returns>
        public async Task UpdateRunway(Runway runway)
        {
            var runwayEntity = _mapper.Map<Entities.Runway>(runway);
            _airportDbContext.Runways.Update(runwayEntity);
        }


        /// <summary>
        /// Save pending changes to database
        /// </summary>
        /// <returns></returns>
        public async Task SaveChangesAsync()
        {
            await this._airportDbContext.SaveChangesAsync();
        }


    }
}