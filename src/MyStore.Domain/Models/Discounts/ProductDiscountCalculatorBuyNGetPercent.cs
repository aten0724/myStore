using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Models.Discounts
{
    public class ProductDiscountCalculatorBuyNGetPercent : IProductDiscountCalculator
    {
        private ProductDiscount discount;
        public ProductDiscountCalculatorBuyNGetPercent(ProductDiscount discount)
        {
            this.discount = discount;
        }

        public float CalculateDiscountSubtotal(CartItem cartItem)
        {
            var n = discount.DiscountQuantity;
            var percent = discount.DiscountValue;
            var quantityOfNotInDiscountSet = cartItem.Quantity % n;
            var numOfDiscountSet = (cartItem.Quantity - quantityOfNotInDiscountSet) / n;
            cartItem.Subtotal = cartItem.Product.UnitPrice * n * numOfDiscountSet * (float)percent + quantityOfNotInDiscountSet * cartItem.Product.UnitPrice;
            return cartItem.Subtotal;
        }
    }
}
