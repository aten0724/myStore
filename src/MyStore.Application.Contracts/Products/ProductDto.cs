using System;
using Volo.Abp.Application.Dtos;

namespace MyStore.Products.Dto
{
    public class ProductDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public float DiscountedPrice { get; set; }
    }
}
