namespace DotNetCore_MultiLanguageSample.Data.Models
{
    /// <summary>
    /// ترجمه محتوا
    /// </summary>
    public class TranslationModel : BaseModel, ITranslationModel
    {
        public IList<TranslationLanguageModel> LanguagesContent { get; set; }
    }
}
