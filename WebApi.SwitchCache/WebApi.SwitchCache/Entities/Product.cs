using MongoDB.Bson.Serialization.Attributes;

using System;

namespace WebApi.SwitchCache.Entities
{
    public class Product
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
    }
}
