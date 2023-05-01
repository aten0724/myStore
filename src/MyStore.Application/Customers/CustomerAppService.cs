using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using MyStore.Models;
using MyStore.Customers.Dto;

namespace MyStore.Customers
{
    public class CustomerAppService :
        CrudAppService<
            Customer,
            CustomerDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCustomerDto>
    {
        private IRepository<Cart, Guid> _cartRepository;
        private IRepository<Customer, Guid> _customerRepository;

        public CustomerAppService(
            IRepository<Customer, Guid> customerRepository,
            IRepository<Cart, Guid> cartRepository
            )
            : base(customerRepository)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
        }

        public override async Task<CustomerDto> CreateAsync(CreateUpdateCustomerDto input)
        {
            var customer = await _customerRepository.FindAsync(c => c.Name == input.Name);
            if (customer != null)
            {
                throw new UserFriendlyException("Customer is already exist");
            }
            customer = ObjectMapper.Map<CreateUpdateCustomerDto, Customer>(input);
            customer = await _customerRepository.InsertAsync(customer);
            var newCart = new Cart()
            {
                CustomerId = customer.Id,
                CartItems = new List<CartItem>()
            };
            var cart = await _cartRepository.InsertAsync(newCart);
            return ObjectMapper.Map<Customer, CustomerDto>(customer);
        }
    }
}
