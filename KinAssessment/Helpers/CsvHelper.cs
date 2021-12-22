using System.Collections.Generic;
using System.Linq;
using KinAssessment.Entities;

namespace KinAssessment.Helpers
{
    public class CsvHelper
    {
        public static List<T> Parse<T>(string[] csv) where T : IKinEntity, new () {
            var list = new List<T>();
            foreach (var s in csv.Skip(1))
            {
                var entity = new T();
                entity.Parse<T>(s);
                list.Add(entity);
            }

            return list;
        }
    }
}