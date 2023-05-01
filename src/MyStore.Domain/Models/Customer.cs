using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace MyStore.Models
{
    public class Customer : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

    }
}
