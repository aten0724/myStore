using System;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Customers.Dto
{
    public class CreateUpdateCustomerDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
    }
}
