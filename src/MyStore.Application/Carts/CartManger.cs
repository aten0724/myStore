using AutoMapper.Internal.Mappers;
using MyStore.Discounts;
using MyStore.Models;
using MyStore.Models.Discounts;
using MyStore.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace MyStore.Carts
{
    public class CartManger : ITransientDependency
    {
        private IRepository<Cart, Guid> _cartRepository;
        private IRepository<Product, Guid> _productRepository;
        private IRepository<ProductDiscount, Guid> _productDiscountRepository;
        private IRepository<CartDiscount, Guid> _cartDiscountRepository;

        public CartManger(
            IRepository<Cart, Guid> cartRepository,
            IRepository<Product, Guid> productRepository,
            IRepository<ProductDiscount, Guid> productDiscountRepository,
            IRepository<CartDiscount, Guid> cartDiscountRepository
            )
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _productDiscountRepository = productDiscountRepository;
            _cartDiscountRepository = cartDiscountRepository;
        }

        public async Task<Cart> GetCartDetail(Cart cart)
        {
            cart.CartItems = await GetProductsDetail(cart.CartItems);
            cart.CartItems = await GetProductDiscountsDetail(cart.CartItems);
            cart.CartDiscounts = await GetCartDiscountsDetail();
            cart.CartItems = CalculateSubTotal(cart.CartItems);
            cart.CartItems = CalculatDiscountedPrice(cart.CartItems);
            cart.TotalPrice = CalculateTotalPrice(cart);
            return cart;
        }

        private async Task<List<CartItem>> GetProductsDetail(List<CartItem> cartItems)
        {
            var productIds = cartItems.Select(i => i.ProductId).ToList();
            var products = await _productRepository.GetListAsync(i => productIds.Contains(i.Id));
            foreach (var cartItem in cartItems)
            {
                cartItem.Product = products.Find(p => cartItem.ProductId == p.Id) ?? throw new UserFriendlyException("Product is not exist");
            }
            return cartItems;
        }

        private async Task<List<CartItem>> GetProductDiscountsDetail(List<CartItem> cartItems)
        {
            var productIds = cartItems.Select(i => i.ProductId).ToList();
            var discounts = await _productDiscountRepository.GetListAsync(
                i => productIds.Contains(i.ProductId)
                && i.ActivePeriod.StartTime < DateTime.Now
                && DateTime.Now <= i.ActivePeriod.EndTime
                );
            foreach (var cartItem in cartItems)
            {
                cartItem.Discounts = discounts.Where(d => cartItem.ProductId == d.ProductId).ToList();
            }
            return cartItems;
        }

        private async Task<List<CartDiscount>> GetCartDiscountsDetail()
        {
            return await _cartDiscountRepository.GetListAsync(i =>
                i.ActivePeriod.StartTime < DateTime.Now
                && DateTime.Now <= i.ActivePeriod.EndTime);
        }

        private List<CartItem> CalculatDiscountedPrice(List<CartItem> cartItems)
        {
            foreach (var cartItem in cartItems)
            {
                cartItem.Product.DiscountedPrice = cartItem.Subtotal / cartItem.Quantity;
            }
            return cartItems;
        }

        private List<CartItem> CalculateSubTotal(List<CartItem> cartItems)
        {
            var calculatorProvider = new ProductDiscountCalculatorProvider();
            foreach (var cartItem in cartItems)
            {
                if (!cartItem.Discounts.Any())
                {
                    cartItem.Subtotal = cartItem.Quantity * cartItem.Product.UnitPrice;
                    continue;
                }
                foreach (var discount in cartItem.Discounts)
                {
                    var discountCalculator = calculatorProvider.GetCalculator(discount);
                    cartItem.Subtotal = discountCalculator.CalculateDiscountSubtotal(cartItem);
                }
            }
            return cartItems;
        }

        private float CalculateTotalPrice(Cart cart)
        {
            cart.TotalPrice = cart.CartItems.Sum(i => i.Subtotal);
            var calculatorProvider = new CartDiscountCalculatorProvider();
            foreach (var discount in cart.CartDiscounts)
            {
                var discountCalculator = calculatorProvider.GetCalculator(discount);
                cart.TotalPrice = discountCalculator.CalculateDiscountTotal(cart.TotalPrice);
            }
            return cart.TotalPrice;
        }
    }
}
