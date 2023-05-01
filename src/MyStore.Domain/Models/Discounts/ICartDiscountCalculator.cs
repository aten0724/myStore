using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Models.Discounts
{
    public interface ICartDiscountCalculator
    {
        public float CalculateDiscountTotal(float total);
    }
}
