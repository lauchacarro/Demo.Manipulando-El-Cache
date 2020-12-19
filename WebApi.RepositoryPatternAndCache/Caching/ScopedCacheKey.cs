namespace WebApi.RepositoryPatternAndCache.Caching
{
    public record ScopedCacheKey(string Entity, string Method, string Parameter = "");
}
