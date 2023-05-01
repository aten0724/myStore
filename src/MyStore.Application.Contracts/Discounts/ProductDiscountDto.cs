using System;
using Volo.Abp.Application.Dtos;

namespace MyStore.Discounts.Dto
{
    public class ProductDiscountDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProductId { get; set; }
        public PeriodDto ActivePeriod { get; set; }
        public string DiscountType { get; set; }
        public float? DiscountValue { get; set; }
        public int DiscountQuantity { get; set; }
    }
}
