using System;
using System.Collections.Generic;
using System.Linq;
using KinAssessment.Entities;
using KinAssessment.Helpers;

namespace KinAssessment
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert the list of product Ids separated by comma (001,002,001...)");

            if (args.Length == 0 || string.IsNullOrEmpty(args[0]))
            {
                throw new Exception("List of products cannot be null");
            }
            
            var productsTyped = args[0].Split(',');

            var discountRules = new List<DiscountRule>();
            
            discountRules.Add(new DiscountRule(75, 10));
            discountRules.Add(new DiscountRule(1, 2, (decimal)22.99));

            var total = Run(productsTyped, discountRules);
            
            Console.WriteLine($"The total is: {total}");
        }

        public static decimal Run(string products, List<DiscountRule> discountRules)
        {
            return Run(products.Split(','), discountRules);
        }
        public static decimal Run(string[] products, List<DiscountRule> discountRules)
        {
            var checkout = new Checkout(discountRules);
            checkout.Scan(GetSelectedProducts(products));
            
            return decimal.Round(checkout.Total(), 2, MidpointRounding.AwayFromZero);;
        }
        
        private static List<int> GetSelectedProducts(string[] products)
        {
            var selectedProducts = new List<int>();

            foreach (var product in products)
            {
                if (Int32.TryParse(product, out var productId))
                {
                    selectedProducts.Add(productId);
                }
            }

            return selectedProducts;
        }
    }
}