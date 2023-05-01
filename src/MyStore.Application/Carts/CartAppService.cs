using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using MyStore.Models;
using MyStore.Customers;
using MyStore.Carts.Dto;

namespace MyStore.Carts
{
    public class CartAppService : ApplicationService
    {
        private IRepository<Cart, Guid> _cartRepository;
        private IRepository<Product, Guid> _productRepository;
        private CartManger _cartManger;

        public CartAppService(
            IRepository<Cart, Guid> cartRepository,
            IRepository<Product, Guid> productRepository,
            CartManger cartManger
            )
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _cartManger = cartManger;
        }

        public async Task<CartDto> GetAsync(CustomerIdDto input)
        {
            var cart = await _cartRepository.FindAsync(c => c.CustomerId == input.CustomerId);
            if (cart == null)
            {
                throw new UserFriendlyException("Cart is not exist");
            }
            cart = await _cartManger.GetCartDetail(cart);
            return ObjectMapper.Map<Cart, CartDto>(cart);
        }

        public async Task<CartDto> UpdateProductToCartAsync(UpdateProductToCartDto input)
        {
            var cart = await _cartRepository.FindAsync(c => c.CustomerId == input.CustomerId);
            if (cart == null)
            {
                throw new UserFriendlyException("Cart is not exist");
            }
            var product = await _productRepository.FindAsync(input.ProductId);
            if (product == null)
            {
                throw new UserFriendlyException("Product is not exist");
            }

            var cartItem = cart.CartItems.Find(i => i.ProductId == input.ProductId);
            if (cartItem == null)
            {
                var newLineItem = new CartItem()
                {
                    Quantity = input.Quantity,
                    ProductId = product.Id
                };
                cart.CartItems.Add(newLineItem);
            }
            else
            {
                cartItem.Quantity = input.Quantity;
            }
            cart.CartItems = cart.CartItems.Where(i => i.Quantity > 0).ToList();
            cart = await _cartRepository.UpdateAsync(cart);
            cart = await _cartManger.GetCartDetail(cart);
            return ObjectMapper.Map<Cart, CartDto>(cart);
        }
    }
}
