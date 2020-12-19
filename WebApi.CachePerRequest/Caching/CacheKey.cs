namespace WebApi.CachePerRequest.Caching
{
    public record CacheKey(string Entity, string Method, string Parameter = "")
    {
        public string TraceIdentifierId { get; set; }
    }
}
