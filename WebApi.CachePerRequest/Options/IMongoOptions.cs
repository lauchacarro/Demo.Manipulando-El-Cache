﻿namespace WebApi.CachePerRequest.Options
{
    public interface IMongoOptions
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CollectionName { get; set; }
    }
}
