using PocMongoDb.Domain.SharedContext.Entities;
using PocMongoDb.Domain.SharedContext.Interfaces;

namespace PocMongoDb.Domain.SharedContext.Domains
{
    public class WeatherForecastDomain : IDomain<WeatherForecastEntity>
    {
        private readonly IBaseRepository<WeatherForecastEntity> _repository;

        public WeatherForecastDomain(IBaseRepository<WeatherForecastEntity> repository) 
        {
            _repository = repository;
        }

        public async Task<WeatherForecastEntity> DeleteAsync(Guid id, CancellationToken cancel)
        {
            return await _repository.DeleteAsync(id, cancel);
        }

        public async Task<WeatherForecastEntity> GetByIdAsync(Guid id, CancellationToken cancel)
        {
            return await _repository.GetByIdAsync(id, cancel);
        }

        public async Task<WeatherForecastEntity> InsertAsync(WeatherForecastEntity data, CancellationToken cancel)
        {
            return await _repository.InsertAsync(data, cancel);
        }

        public async Task<IEnumerable<WeatherForecastEntity>> InsertManyAsync(IEnumerable<WeatherForecastEntity> data, CancellationToken cancel)
        {
            return await _repository.InsertManyAsync(data, cancel);
        }

        public async Task<IEnumerable<WeatherForecastEntity>> ListAsync(CancellationToken cancel)
        {
            return await _repository.ListAsync(cancel);
        }

        public async Task<WeatherForecastEntity> UpdateAsync(WeatherForecastEntity data, CancellationToken cancel)
        {
            return await _repository.UpdateAsync(data, cancel);
        }
    }
}
