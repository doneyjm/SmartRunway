using Microsoft.Extensions.DependencyInjection;
using SmartRunwayApi.Data;
using SmartRunwayApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRunwayApi
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider service)
        {
            await AddTestData(service.GetRequiredService<AirportDbContext>());
        }

        //Setting up the in-memory db.
        public static async Task AddTestData(AirportDbContext airportDbContext)
        {
            airportDbContext.Runways.Add(new Runway
            {
                Id = 1,
                Name = "Runway1",
                Landings = new List<Landing>(),
                TakeOffs = new List<TakeOff>(),
                NextAvailableTime = DateTimeOffset.Now.AddMinutes(45)
            });

            airportDbContext.Runways.Add(new Runway
            {
                Id = 2,
                Name = "Runway2",
                Landings = new List<Landing>(),
                TakeOffs = new List<TakeOff>(),
                NextAvailableTime = DateTimeOffset.Now.AddMinutes(60)
            });

            airportDbContext.Flights.Add(new Flight
            {
                Id = 1,
                LandingDuration = new TimeSpan(0, 7, 0),
                Name = "Flight1",
                TakeOffDuration = new TimeSpan(0, 9, 0)
            });

            airportDbContext.Flights.Add(new Flight
            {
                Id = 2,
                LandingDuration = new TimeSpan(0, 8, 0),
                Name = "Flight2",
                TakeOffDuration = new TimeSpan(0, 9, 0)
            });

            airportDbContext.Flights.Add(new Flight
            {
                Id = 3,
                LandingDuration = new TimeSpan(0, 10, 0),
                Name = "Flight3",
                TakeOffDuration = new TimeSpan(0, 12, 0)
            });

            airportDbContext.Flights.Add(new Flight
            {
                Id = 4,
                LandingDuration = new TimeSpan(0, 8, 0),
                Name = "Flight4",
                TakeOffDuration = new TimeSpan(0, 8, 0)
            });

            airportDbContext.Flights.Add(new Flight
            {
                Id = 5,
                LandingDuration = new TimeSpan(0, 11, 0),
                Name = "Flight5",
                TakeOffDuration = new TimeSpan(0, 9, 0)
            });

            airportDbContext.Flights.Add(new Flight
            {
                Id = 6,
                LandingDuration = new TimeSpan(0, 7, 0),
                Name = "Flight6",
                TakeOffDuration = new TimeSpan(0, 9, 0)
            });

            airportDbContext.Flights.Add(new Flight
            {
                Id = 7,
                LandingDuration = new TimeSpan(0, 10, 0),
                Name = "Flight7",
                TakeOffDuration = new TimeSpan(0, 10, 0)
            });

            await airportDbContext.SaveChangesAsync();
        }
    }
}