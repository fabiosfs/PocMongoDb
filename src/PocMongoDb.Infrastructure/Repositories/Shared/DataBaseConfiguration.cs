namespace PocMongoDb.Domain.Repositories.Shared
{
    public class DataBaseConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public bool IsSSL { get; set; }
    }
}
