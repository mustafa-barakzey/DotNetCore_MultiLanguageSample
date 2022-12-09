namespace DotNetCore_MultiLanguageSample.Data.Models
{
    public class ProductModel:BaseModel
    {
        public int TitleId { get; set; }
        public TranslationModel Title { get; set; }

        public TranslationModel ShortDescription { get; set; }
        public int ShortDescriptionId { get; set; }

        public TranslationModel LongDescription { get; set; }
        public int LongDescriptionId { get; set; }

        public decimal Price { get; set; }
    }
}
