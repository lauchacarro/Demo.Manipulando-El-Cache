using MongoDB.Bson.Serialization.Attributes;

using System;

namespace WebApi.CachePerEntity.Entities
{
    public class User : IEntity<Guid>
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
