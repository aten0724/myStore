using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using MyStore.Models;
using MyStore.Products.Dto;

namespace MyStore.Products
{
    public class ProductAppService :
        CrudAppService<
            Product,
            ProductDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateProductDto>
    {
        public ProductAppService(IRepository<Product, Guid> repository)
            : base(repository)
        {
        }

    }
}
