using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MyStore.Models
{
    public class CartItem
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        [BsonIgnore]
        public float Subtotal { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
        [BsonIgnore]
        public List<ProductDiscount> Discounts { get; set; }
    }
}
