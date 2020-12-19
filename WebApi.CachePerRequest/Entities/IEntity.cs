namespace WebApi.CachePerRequest.Entities
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
