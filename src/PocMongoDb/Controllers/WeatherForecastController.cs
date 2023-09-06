using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocMongoDb.Domain.SharedContext.Dtos;
using PocMongoDb.Domain.SharedContext.Interfaces;

namespace PocMongoDb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IDomain<WeatherForecastDto> _domain;

        public WeatherForecastController(IDomain<WeatherForecastDto> domain)
        {
            _domain = domain;
            
        }

        [HttpDelete("{id}")]
        public async Task<WeatherForecastDto> DeleteAsync(Guid id, CancellationToken cancel)
        {
            return await _domain.DeleteAsync(id, cancel);
        }

        [HttpGet("{id}")]
        public async Task<WeatherForecastDto> GetByIdAsync(Guid id, CancellationToken cancel)
        {
            return await _domain.GetByIdAsync(id, cancel);
        }

        [HttpPost]
        public async Task<WeatherForecastDto> InsertAsync([FromBody]WeatherForecastDto data, CancellationToken cancel)
        {
            return await _domain.InsertAsync(data, cancel);
        }

        [HttpPost("many")]
        public async Task<IEnumerable<WeatherForecastDto>> InsertManyAsync(IEnumerable<WeatherForecastDto> data, CancellationToken cancel)
        {
            if (data == null || data.Count() == 0)
            {
                string[] Summaries = new[]
                {
                    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                };
                data = Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                });
            }
            return await _domain.InsertManyAsync(data, cancel);
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecastDto>> ListAsync(CancellationToken cancel)
        {
            return await _domain.ListAsync(cancel);
        }

        [HttpPut("{id}")]
        public async Task<WeatherForecastDto> UpdateAsync(WeatherForecastDto data, CancellationToken cancel)
        {
            return await _domain.UpdateAsync(data, cancel);
        }
    }
}