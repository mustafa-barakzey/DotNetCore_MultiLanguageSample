namespace DotNetCore_MultiLanguageSample.Data.Models;

public interface ITranslationModel
{
    public IList<TranslationLanguageModel> LanguagesContent { get; set; }
}