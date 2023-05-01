using MyStore.Discounts.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Discounts.Dto
{
    public class CreateUpdateProductDiscountDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public PeriodDto ActivePeriod { get; set; }
        [Required]
        public float DiscountValue { get; set; }
        [Required]
        public string DiscountType { get; set; }
        [Required]
        public int DiscountQuantity { get; set; }
    }
}
