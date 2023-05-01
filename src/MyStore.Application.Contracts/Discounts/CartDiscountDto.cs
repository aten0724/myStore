using System;
using Volo.Abp.Application.Dtos;

namespace MyStore.Discounts.Dto
{
    public class CartDiscountDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PeriodDto ActivePeriod { get; set; }
        public string DiscountType { get; set; }
        public float DiscountValue { get; set; }
        public float DiscountPrice { get; set; }
    }
}
