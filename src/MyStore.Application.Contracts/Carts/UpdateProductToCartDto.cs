using System;

namespace MyStore.Carts.Dto
{
    public class UpdateProductToCartDto
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
