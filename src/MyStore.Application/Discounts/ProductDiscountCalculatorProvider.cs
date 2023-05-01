using System;
using MyStore.Models;
using MyStore.Models.Discounts;

namespace MyStore.Discounts
{
    public class ProductDiscountCalculatorProvider
    {
        public ProductDiscountCalculatorProvider()
        {
        }
        public IProductDiscountCalculator GetCalculator(ProductDiscount productDiscount)
        {
            return productDiscount.DiscountType switch
            {
                ProductDiscountTypes.BuyNGetPercent => new ProductDiscountCalculatorBuyNGetPercent(productDiscount),
                ProductDiscountTypes.BuyNGetYFree => new ProductDiscountCalculatorBuyNGetYFree(productDiscount),
                _ => throw new ArgumentOutOfRangeException(nameof(productDiscount.DiscountType), $"Not expected product discount type: {productDiscount.DiscountType}"),
            };
        }
    }
}
