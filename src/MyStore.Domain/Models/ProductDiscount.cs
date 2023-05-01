using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Domain.Entities.Auditing;

namespace MyStore.Models
{
    public class ProductDiscount : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProductId { get; set; }
        public Period ActivePeriod { get; set; }
        public string DiscountType { get; set; }
        public float? DiscountValue { get; set; }
        public int DiscountQuantity { get; set; }


    }
}
