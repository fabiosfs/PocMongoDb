using AutoMapper;
using PocMongoDb.Domain.SharedContext.Dtos;
using PocMongoDb.Domain.SharedContext.Entities;

namespace PocMongoDb.Domain.CompanyContext.Mapper
{
    public class WeatherForecastMapper : Profile
    {
        public WeatherForecastMapper()
        {
            CreateMap<WeatherForecastDto, WeatherForecastEntity>()
                .ReverseMap();
        }
    }
}
