namespace DotNetCore_MultiLanguageSample.Data.Models;

/// <summary>
/// ترجمه زبان ها
/// </summary>
public class TranslationLanguageModel : BaseModel
{
    public TranslationLanguageModel()
    {
        
    }
    public TranslationLanguageModel(string content,Language language=Language.Engilsh)
    {
        Content = content;
        Language = language;
    }
    public Language Language { get; set; }
    public string Content { get; set; }
    public TranslationModel Translation { get; set; }
    public int TranslationId { get; set; }
}