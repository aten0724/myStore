using MongoDB.Bson.Serialization.Attributes;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace MyStore.Models
{
    public class Product : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        [BsonIgnore]
        public float DiscountedPrice { get; set; }
    }
}
