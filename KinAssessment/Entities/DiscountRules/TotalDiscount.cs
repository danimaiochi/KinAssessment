using System.Collections.Generic;

namespace KinAssessment.Entities.DiscountRules
{
    public class TotalDiscount : IDiscountRule
    {
        public decimal MinValue { get; set; }
        public decimal DiscountPercentage { get; set; }
        
        public TotalDiscount(decimal minValue, decimal discountPercentage)
        {
            MinValue = minValue;
            DiscountPercentage = discountPercentage;
        }

        public decimal GetDiscountedValue(decimal total)
        {
            if (total > MinValue)
            {
                total = -((DiscountPercentage / 100) * total) + total;
            }

            return total;
        }
    }
}