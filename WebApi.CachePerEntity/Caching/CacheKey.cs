namespace WebApi.CachePerEntity.Caching
{
    public record CacheKey(string Entity, string Method, string Parameter = "");
}
