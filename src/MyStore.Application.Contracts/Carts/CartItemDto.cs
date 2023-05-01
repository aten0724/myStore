using System;
using System.Collections.Generic;
using MyStore.Discounts.Dto;
using MyStore.Products.Dto;

namespace MyStore.Carts.Dto
{
    public class CartItemDto
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public float Subtotal { get; set; }
        public virtual ProductDto Product { get; set; }
        public virtual List<ProductDiscountDto> Discounts { get; set; }
    }
}
