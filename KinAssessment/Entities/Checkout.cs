using System;
using System.Collections.Generic;
using System.Linq;
using KinAssessment.Entities.DiscountRules;
using KinAssessment.Helpers;

namespace KinAssessment.Entities
{
    public class Checkout
    {
        public List<int> ProductIds { get; set; }
        public List<IDiscountRule> DiscountRules { get; set; }

        public Checkout(List<IDiscountRule> discountRules)
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
            
            foreach (var discountRule in DiscountRules)
            {
                if (discountRule is PriceModification ds)
                {
                    availableProducts = ds.GetUpdatedPrices(ProductIds, availableProducts);
                }
            }

            foreach (var productId in ProductIds)
            {
                total += availableProducts.FirstOrDefault(x => x.Id == productId)?.Price ?? 0;
            }
            
            foreach (var discountRule in DiscountRules)
            {
                if (discountRule is TotalDiscount ds)
                {
                    total = ds.GetDiscountedValue(total);
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