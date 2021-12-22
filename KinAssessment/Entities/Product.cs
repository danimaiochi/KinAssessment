using System;

namespace KinAssessment.Entities
{
    public class Product : IKinEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public void Parse<T>(string csvLine)
        {
            var values = csvLine.Split(',');
            
            Id = Convert.ToInt32(values[0]);
            Name = values[1];
            Price = Convert.ToDecimal(values[2]);
        }
    }

}