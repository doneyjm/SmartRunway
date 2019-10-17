using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SmartRunwayApi.Data;
using SmartRunwayApi.Filters;
using SmartRunwayApi.Infrastructure;
using SmartRunwayApi.Models;
using SmartRunwayApi.Services;

namespace SmartRunwayApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AirportDbContext>(options =>
            options.UseInMemoryDatabase("AirportDb"));

            services.AddMvc(options =>
            {
                options.Filters.Add<JsonExceptionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddRouting(options => options.LowercaseUrls = true);
            services.Configure<BufferTime>(Configuration.GetSection("BufferTime"));

            services.AddSwaggerDocument(
               options => options.PostProcess = document =>
               {
                   document.Info.Version = "v1";
                   document.Info.Title = "Smart Runway API";
                   document.Info.Description = "An API to handle airport runway allocation.";
               }
           );

            services.AddScoped<IFlightSchedulerService, FlightSchedulerService>();
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IAirportRepository, AirportRepository>();


            services.AddAutoMapper(
                        options => options.AddProfile<MappingProfile>());
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSmartRunwayApp",
                    policy => policy.AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUi3();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowSmartRunwayApp");
            app.UseMvc();
        }
    }
}
