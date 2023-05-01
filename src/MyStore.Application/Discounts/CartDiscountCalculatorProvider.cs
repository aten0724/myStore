using System;
using MyStore.Models;
using MyStore.Models.Discounts;

namespace MyStore.Discounts
{
    public class CartDiscountCalculatorProvider
    {
        public CartDiscountCalculatorProvider()
        {
        }
        public ICartDiscountCalculator GetCalculator(CartDiscount cartDiscount)
        {
            return cartDiscount.DiscountType switch
            {
                CartDiscountTypes.PriceBreak => new CartDiscountCalculatorPriceBreak(cartDiscount),
                _ => throw new ArgumentOutOfRangeException(nameof(cartDiscount.DiscountType), $"Not expected cart discount type: {cartDiscount.DiscountType}"),
            };
        }
    }
}
