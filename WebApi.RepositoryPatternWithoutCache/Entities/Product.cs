using MongoDB.Bson.Serialization.Attributes;

using System;

namespace WebApi.RepositoryPatternWithoutCache.Entities
{
    public class Product : IEntity<Guid>
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
    }
}
