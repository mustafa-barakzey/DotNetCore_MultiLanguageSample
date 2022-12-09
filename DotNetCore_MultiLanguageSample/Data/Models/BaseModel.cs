namespace DotNetCore_MultiLanguageSample.Data.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            var random = new Random();
            Id=random.Next();
        }
        public int Id { get; set; }
    }
}
