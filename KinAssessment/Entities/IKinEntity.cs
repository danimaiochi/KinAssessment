namespace KinAssessment.Entities
{
    public interface IKinEntity
    {
        public void Parse<T>(string csvLine);
    }
}