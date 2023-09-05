using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PocMongoDb.Domain.Repositories.Shared;
using PocMongoDb.Domain.SharedContext.Entities;
using PocMongoDb.Domain.SharedContext.Interfaces;
using PocMongoDb.Infrastructure.Repositories.Company;

namespace PocMongoDb.Infrastructure
{
    public static class StartUp
    {
        public static void InjectionInfrastructure(this IServiceCollection services, DataBaseConfiguration dataBaseConfiguration)
        {
            // Repositories Injections
            services.AddSingleton<IBaseRepository<WeatherForecastEntity>, WeatherForecastRepository>();

            // Configuração do mongo db
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(dataBaseConfiguration.ConnectionString));
            if (dataBaseConfiguration.IsSSL)
            {
                settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            }
            var client = new MongoClient(settings);
            var database = client.GetDatabase(dataBaseConfiguration.DatabaseName);
            services.AddSingleton(database);
        }
    }
}
