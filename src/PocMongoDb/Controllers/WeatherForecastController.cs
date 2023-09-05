using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocMongoDb.Domain.SharedContext.Dtos;
using PocMongoDb.Domain.SharedContext.Entities;
using PocMongoDb.Domain.SharedContext.Interfaces;

namespace PocMongoDb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IDomain<WeatherForecastEntity> _domain;
        private readonly IMapper _mapper;
        public WeatherForecastController(IDomain<WeatherForecastEntity> domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        [HttpDelete("{id}")]
        public async Task<WeatherForecastDto> DeleteAsync(Guid id, CancellationToken cancel)
        {
            return _mapper.Map<WeatherForecastDto>(await _domain.DeleteAsync(id, cancel));
        }

        [HttpGet("{id}")]
        public async Task<WeatherForecastDto> GetByIdAsync(Guid id, CancellationToken cancel)
        {
            return _mapper.Map<WeatherForecastDto>(await _domain.GetByIdAsync(id, cancel));
        }

        [HttpPost]
        public async Task<WeatherForecastDto> InsertAsync([FromBody]WeatherForecastDto data, CancellationToken cancel)
        {
            return _mapper.Map<WeatherForecastDto>(await _domain.InsertAsync(_mapper.Map<WeatherForecastEntity>(data), cancel));
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
            return _mapper.Map<IEnumerable<WeatherForecastDto>>(await _domain.InsertManyAsync(_mapper.Map<IEnumerable<WeatherForecastEntity>>(data), cancel));
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecastDto>> ListAsync(CancellationToken cancel)
        {
            return _mapper.Map<IEnumerable<WeatherForecastDto>>(await _domain.ListAsync(cancel));
        }

        [HttpPut("{id}")]
        public async Task<WeatherForecastDto> UpdateAsync(WeatherForecastDto data, CancellationToken cancel)
        {
            return _mapper.Map<WeatherForecastDto>(await _domain.UpdateAsync(_mapper.Map<WeatherForecastEntity>(data), cancel));
        }
    }
}