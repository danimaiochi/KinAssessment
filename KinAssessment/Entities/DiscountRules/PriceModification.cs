using System.Collections.Generic;
using System.Linq;

namespace KinAssessment.Entities.DiscountRules
{
    public class PriceModification : IDiscountRule
    {
        public int ProductId { get; set; }
        public int MinQuantity { get; set; }
        public decimal NewPrice { get; set; }
        
        public PriceModification(int productId, int minQuantity, decimal newPrice)
        {
            ProductId = productId;
            MinQuantity = minQuantity;
            NewPrice = newPrice;
        }

        public List<Product> GetUpdatedPrices(List<int> productIds, List<Product> availableProducts)
        {
            var updatedList = availableProducts;

            if (productIds.Count(x => x == ProductId) >= MinQuantity)
            {
                availableProducts.First(x => x.Id == ProductId).Price = NewPrice;
            }

            return updatedList;
        }
    }
}