using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Models.Discounts
{
    public interface IProductDiscountCalculator
    {
        public float CalculateDiscountSubtotal(CartItem cartItem);
    }
}
