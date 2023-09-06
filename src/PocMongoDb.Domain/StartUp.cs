using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PocMongoDb.Domain.CompanyContext.Mapper;
using PocMongoDb.Domain.SharedContext.Domains;
using PocMongoDb.Domain.SharedContext.Dtos;
using PocMongoDb.Domain.SharedContext.Interfaces;

namespace PocMongoDb.Domain
{
    public static class StartUp
    {
        public static void InjectionDomain(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<WeatherForecastMapper>();
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton<IDomain<WeatherForecastDto>, WeatherForecastDomain>();
        }
    }
}
