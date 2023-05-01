using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Models.Discounts
{
    public class ProductDiscountCalculatorBuyNGetYFree : IProductDiscountCalculator
    {
        private ProductDiscount discount;
        public ProductDiscountCalculatorBuyNGetYFree(ProductDiscount discount)
        {
            this.discount = discount;
        }

        public float CalculateDiscountSubtotal(CartItem cartItem)
        {
            var n = discount.DiscountQuantity;
            var y = (int)discount.DiscountValue;
            var quantityOfNotInDiscountSet = cartItem.Quantity % (n + y);
            var numOfDiscountSet = (cartItem.Quantity - quantityOfNotInDiscountSet) / (n + y);
            cartItem.Subtotal = cartItem.Product.UnitPrice * n * numOfDiscountSet + quantityOfNotInDiscountSet * cartItem.Product.UnitPrice;
            return cartItem.Subtotal;
        }
    }
}
