namespace PocMongoDb.Infrastructure.Repositories.Utils
{
    public static class Util
    {
        public static string PegarNomeCollection(Type tipo)
        {
            return tipo.Name.Replace("Entity", "");
        }
    }
}
