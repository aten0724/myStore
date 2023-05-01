using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using MyStore.Models;
using MyStore.Discounts.Dto;

namespace MyStore.Discounts
{
    public class CartDiscountAppService :
        CrudAppService<
            CartDiscount,
            CartDiscountDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCartDiscountDto>
    {
        public CartDiscountAppService(
            IRepository<CartDiscount, Guid> discountRepository
            )
            : base(discountRepository)
        {
        }
    }
}
