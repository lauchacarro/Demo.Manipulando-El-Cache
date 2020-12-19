namespace WebApi.CachePerRequest.Caching
{
    public record ScopedCacheKey(string Entity, string Method, string Parameter = "")
    {
        public string TraceIdentifierId { get; set; }
    }
}
