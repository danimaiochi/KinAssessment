using System;
using System.Collections.Generic;
using System.Linq;
using KinAssessment.Helpers;

namespace KinAssessment.Entities
{
    public class Checkout
    {
        public List<int> ProductIds { get; set; }
        public List<DiscountRule> DiscountRules { get; set; }

        public Checkout(List<DiscountRule> discountRules)
        {
            DiscountRules = discountRules;
        }
        public void Scan(List<int> products)
        {
            if (ProductIds == null)
            {
                ProductIds = new List<int>();
            }
            ProductIds.AddRange(products);
        }

        public decimal Total()
        {
            var availableProducts = GetAllProducts();
            decimal total = 0;
            
            foreach (var discountRule in DiscountRules.Where(x => x.DiscountRuleType == DiscountRuleType.Before))
            {
                if (ProductIds.Count(x => x == discountRule.ProductId) >= discountRule.MinQuantity)
                {
                    availableProducts.First(x => x.Id == discountRule.ProductId).Price = discountRule.NewPrice;
                }
            }

            foreach (var productId in ProductIds)
            {
                total += availableProducts.FirstOrDefault(x => x.Id == productId)?.Price ?? 0;
            }

            foreach (var discountRule in DiscountRules.Where(x => x.DiscountRuleType == DiscountRuleType.After))
            {
                if (total > discountRule.MinValue)
                {
                    total = -((discountRule.DiscountPercentage / 100) * total) + total;
                }
            }

            return total;
        }
        
        
        private static List<Product> GetAllProducts()
        {
            var productsData = System.IO.File.ReadAllLines("Data\\products.csv");
            return CsvHelper.Parse<Product>(productsData);
        }
    }
}