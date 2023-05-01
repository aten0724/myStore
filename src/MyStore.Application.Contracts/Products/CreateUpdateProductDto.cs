using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyStore.Products.Dto
{
    public class CreateUpdateProductDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public float UnitPrice { get; set; }
    }
}
