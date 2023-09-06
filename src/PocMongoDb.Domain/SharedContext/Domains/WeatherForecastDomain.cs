using AutoMapper;
using PocMongoDb.Domain.SharedContext.Dtos;
using PocMongoDb.Domain.SharedContext.Entities;
using PocMongoDb.Domain.SharedContext.Interfaces;

namespace PocMongoDb.Domain.SharedContext.Domains
{
    public class WeatherForecastDomain : IDomain<WeatherForecastDto>
    {
        private readonly IBaseRepository<WeatherForecastEntity> _repository;
        private readonly IMapper _mapper;

        public WeatherForecastDomain(IBaseRepository<WeatherForecastEntity> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WeatherForecastDto> DeleteAsync(Guid id, CancellationToken cancel)
        {
            var result = await _repository.DeleteAsync(id, cancel);
            return _mapper.Map<WeatherForecastDto>(result);
        }

        public async Task<WeatherForecastDto> GetByIdAsync(Guid id, CancellationToken cancel)
        {
            var result = await _repository.GetByIdAsync(id, cancel);
            return _mapper.Map<WeatherForecastDto>(result);
        }

        public async Task<WeatherForecastDto> InsertAsync(WeatherForecastDto data, CancellationToken cancel)
        {
            var record = _mapper.Map<WeatherForecastEntity>(data);
            var result = await _repository.InsertAsync(record, cancel);
            return _mapper.Map<WeatherForecastDto>(result);
        }

        public async Task<IEnumerable<WeatherForecastDto>> InsertManyAsync(IEnumerable<WeatherForecastDto> data, CancellationToken cancel)
        {
            var record = _mapper.Map<IEnumerable<WeatherForecastEntity>>(data);
            var result = await _repository.InsertManyAsync(record, cancel);
            return _mapper.Map<IEnumerable<WeatherForecastDto>>(result);
        }

        public async Task<IEnumerable<WeatherForecastDto>> ListAsync(CancellationToken cancel)
        {
            var result = await _repository.ListAsync(cancel);
            return _mapper.Map<IEnumerable<WeatherForecastDto>>(result);
        }

        public async Task<WeatherForecastDto> UpdateAsync(WeatherForecastDto data, CancellationToken cancel)
        {
            var record = _mapper.Map<WeatherForecastEntity>(data);
            var result = await _repository.UpdateAsync(record, cancel);
            return _mapper.Map<WeatherForecastDto>(result);
        }
    }
}
