namespace WebApi.RepositoryPatternWithoutCache.Entities
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
