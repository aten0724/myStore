using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using MyStore.Models;
using MyStore.Discounts.Dto;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.ObjectMapping;

namespace MyStore.Discounts
{
    public class ProductDiscountAppService :
        CrudAppService<
            ProductDiscount,
            ProductDiscountDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateProductDiscountDto>
    {
        private IRepository<ProductDiscount, Guid> _discountRepository;
        private IRepository<Product, Guid> _productRepository;

        public ProductDiscountAppService(
            IRepository<ProductDiscount, Guid> discountRepository,
            IRepository<Product, Guid> productRepository
            )
            : base(discountRepository)
        {
            _discountRepository = discountRepository;
            _productRepository = productRepository;
        }

        public override async Task<ProductDiscountDto> CreateAsync(CreateUpdateProductDiscountDto input)
        {
            var product = await _productRepository.FindAsync(input.ProductId);
            if (product == null)
            {
                throw new UserFriendlyException("Product is not exist");
            }
            var discount = ObjectMapper.Map<CreateUpdateProductDiscountDto, ProductDiscount>(input);
            discount = await _discountRepository.InsertAsync(discount);
            return ObjectMapper.Map<ProductDiscount, ProductDiscountDto>(discount);
        }

    }
}
