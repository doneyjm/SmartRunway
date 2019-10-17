using AutoMapper;
using SmartRunwayApi.Models;
using Entity = SmartRunwayApi.Data.Entities;

namespace SmartRunwayApi.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entity.Flight, Flight>().ReverseMap();
            CreateMap<Entity.Runway, Runway>().ReverseMap();
            CreateMap<Entity.Landing, Landing>().ReverseMap();
            CreateMap<Entity.TakeOff, TakeOff>().ReverseMap();
        }
    }
}