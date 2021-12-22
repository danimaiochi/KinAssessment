using System.Collections.Generic;
using KinAssessment.Entities;
using NUnit.Framework;

namespace KinAssessment.Tests
{
    public class Tests
    {
        [Test]
        [TestCase("001,001,002,003", 103.47)]
        [TestCase("1,1,1", 68.97)]
        [TestCase("2,2,3", 120.59)]
        public void Run_WithExampleValues_ShouldReturnTotal(string productIds, decimal expectedValue)
        {
            var discountRules = new List<DiscountRule>();
            
            discountRules.Add(new DiscountRule(75, 10));
            discountRules.Add(new DiscountRule(1, 2, (decimal)22.99));
            var result = Program.Run(productIds, discountRules);
            Assert.That(expectedValue, Is.EqualTo(result));
        }
        
        [Test]
        [TestCase("dsadsa,565", 0)]
        [TestCase("0,1,d", 24.95)]
        public void Run_WithInvalidValues_ShouldIgnoreInvalidOnes(string productIds, decimal expectedValue)
        {
            var discountRules = new List<DiscountRule>();
            
            discountRules.Add(new DiscountRule(75, 10));
            discountRules.Add(new DiscountRule(1, 2, (decimal)22.99));
            var result = Program.Run(productIds, discountRules);
            Assert.That(expectedValue, Is.EqualTo(result));
        }
    }
}