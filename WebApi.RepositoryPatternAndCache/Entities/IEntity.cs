namespace WebApi.RepositoryPatternAndCache.Entities
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
