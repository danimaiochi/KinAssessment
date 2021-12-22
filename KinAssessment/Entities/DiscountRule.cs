namespace KinAssessment.Entities
{
    public class DiscountRule
    {
        public int ProductId { get; set; }
        public int MinQuantity { get; set; }
        public decimal NewPrice { get; set; }
        
        public decimal MinValue { get; set; }
        public decimal DiscountPercentage { get; set; }
        
        public DiscountRuleType DiscountRuleType { get; set; }

        public DiscountRule(int id, int minQuantity, decimal newPrice)
        {
            ProductId = id;
            MinQuantity = minQuantity;
            NewPrice = newPrice;
            DiscountRuleType = DiscountRuleType.Before;
        }

        public DiscountRule(decimal minValue, decimal discountPercentage)
        {
            MinValue = minValue;
            DiscountPercentage = discountPercentage;
            DiscountRuleType = DiscountRuleType.After;
        }
    }

    public enum DiscountRuleType
    {
        Before,
        After
    }
}