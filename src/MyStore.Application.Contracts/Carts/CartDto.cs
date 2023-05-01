using MyStore.Discounts.Dto;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace MyStore.Carts.Dto
{
    public class CartDto : EntityDto<Guid>
    {
        public Guid CustomerId { get; set; }
        public virtual List<CartItemDto> CartItems { get; set; }
        public float TotalPrice { get; set; }
        public List<CartDiscountDto> CartDiscounts { get; set; }
    }
}
