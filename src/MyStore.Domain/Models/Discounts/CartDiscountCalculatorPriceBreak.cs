using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Models.Discounts
{
    public class CartDiscountCalculatorPriceBreak : ICartDiscountCalculator
    {
        private CartDiscount discount;
        public CartDiscountCalculatorPriceBreak(CartDiscount discount)
        {
            this.discount = discount;
        }

        public float CalculateDiscountTotal(float total)
        {
            var discountValue = discount.DiscountValue;
            if (total >= discount.DiscountValue)
            {
                return total - (float)discount.DiscountPrice;
            }
            return total;
        }
    }
}
