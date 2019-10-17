using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartRunwayApi.Models;
using SmartRunwayApi.Services;
using System.Threading.Tasks;

namespace SmartRunwayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly IFlightSchedulerService _flightSchedulerService;
        private readonly BufferTime _defaultBuffer;

        public AirportController(IWeatherService weatherService,
            IFlightSchedulerService flightSchedulerService,
            IOptions<BufferTime> defaultBuffer)
        {
            this._weatherService = weatherService;
            this._flightSchedulerService = flightSchedulerService;
            this._defaultBuffer = defaultBuffer.Value;
        }

        [HttpPost("Landing")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Landing>> ScheduleLanding([FromBody] Flight flight, [FromQuery] BufferTime bufferTime)
        {
            var buffer = bufferTime.LandingBuffer ?? _defaultBuffer.LandingBuffer.Value;
            var weatherOffset = _weatherService.GetDelayDueToBadWeather();

            if (weatherOffset == -1)
            {
                return BadRequest("Cannot Land due to bad weather.");
            }

            return Ok(await _flightSchedulerService.ScheduleLanding(flight, buffer, weatherOffset));
        }

        [HttpPost("TakeOff")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<TakeOff>> ScheduleTakeOff([FromBody] Flight flight, [FromQuery] BufferTime bufferTime)
        {
            var buffer = bufferTime.TakeOffBuffer ?? _defaultBuffer.TakeOffBuffer.Value;
            var weatherOffset = _weatherService.GetDelayDueToBadWeather();

            if (weatherOffset == 1)
            {
                return BadRequest("Cannot Take Off due to bad weather.");
            }

            return Ok(await _flightSchedulerService.ScheduleTakeOff(flight, buffer, weatherOffset));
        }
    }
}