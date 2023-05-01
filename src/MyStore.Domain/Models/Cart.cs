using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace MyStore.Models
{
    public class Cart : AuditedAggregateRoot<Guid>
    {
        public Guid CustomerId { get; set; }
        public virtual List<CartItem> CartItems { get; set; }
        [BsonIgnore]
        public float TotalPrice { get; set; }
        [BsonIgnore]
        public List<CartDiscount> CartDiscounts { get; set; }
    }
}
