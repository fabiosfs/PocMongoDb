namespace PocMongoDb.Domain.SharedContext.Entities
{
    public class WeatherForecastEntity : BaseEntity
    {
        public DateTime Date { get; private set; }

        public int TemperatureC { get; private set; }

        public int TemperatureF { get; private set; }

        public string? Summary { get; private set; }

        public WeatherForecastEntity(DateTime date, int temperatureC, int temperatureF, string? summary)
        {
            ChangeDate(date);
            ChangeTemperatureC(temperatureC);
            ChangeTemperatureF(temperatureF);
            ChangeSummary(summary);
        }

        public void ChangeDate(DateTime date)
        {
            Date = date;
        }

        public void ChangeTemperatureC(int temperatureC)
        {
            TemperatureC = temperatureC;
        }

        public void ChangeTemperatureF(int temperatureF)
        {
            TemperatureF = temperatureF;
        }

        public void ChangeSummary(string summary)
        {
            Summary = summary;
        }
    }
}
