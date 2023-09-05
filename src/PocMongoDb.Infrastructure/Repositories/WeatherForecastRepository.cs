using MongoDB.Driver;
using PocMongoDb.Domain.Repositories.Shared;
using PocMongoDb.Domain.SharedContext.Entities;
using PocMongoDb.Domain.SharedContext.Interfaces;
using PocMongoDb.Infrastructure.Repositories.Utils;

namespace PocMongoDb.Infrastructure.Repositories.Company
{
    public class WeatherForecastRepository : BaseRepository<WeatherForecastEntity>, IBaseRepository<WeatherForecastEntity>
    {
        public WeatherForecastRepository(IMongoDatabase database) : base(database, Util.PegarNomeCollection(typeof(WeatherForecastEntity)))
        {

        }
    }
}
