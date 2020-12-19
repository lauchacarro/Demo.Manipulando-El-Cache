namespace WebApi.CachePerRequest.Options
{
    public class MongoOptions : IMongoOptions
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
