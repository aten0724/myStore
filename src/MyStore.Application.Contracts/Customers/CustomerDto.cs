using System;
using Volo.Abp.Application.Dtos;

namespace MyStore.Customers.Dto
{
    public class CustomerDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
