using System.ComponentModel.DataAnnotations;

namespace MyStore.Discounts.Dto
{
    public class CreateUpdateCartDiscountDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public PeriodDto ActivePeriod { get; set; }
        [Required]
        public string DiscountType { get; set; }
        [Required]
        public float DiscountValue { get; set; }
        [Required]
        public float DiscountPrice { get; set; }
    }
}
