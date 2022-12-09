using System.Linq.Expressions;
using DotNetCore_MultiLanguageSample.Data.Context;
using DotNetCore_MultiLanguageSample.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DotNetCore_MultiLanguageSample.Infra.TranslationHelper
{
    public static class TranslationHelper
    {
        private static Language DefaultLanguage => Language.Engilsh;

        /// <summary>
        /// for get content 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProp"></typeparam>
        /// <param name="source"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IIncludableQueryable<T, TProp> IncludeDefaultLanguage<T, TProp>(this IQueryable<T> source,
            Expression<Func<T, TProp>> expression) where T : BaseModel where TProp : ITranslationModel => source
            .Include(expression)
            .ThenInclude(m => m.LanguagesContent.Where(l => l.Language == DefaultLanguage))
            .Include(expression);

        /// <summary>
        /// for get content 
        /// </summary>
        /// <returns></returns>
        public static IIncludableQueryable<TEntity, IEnumerable<TranslationLanguageModel>> ThenIncludeDefaultLanguage<TEntity, TPrevious, TProp>(this IIncludableQueryable<TEntity, TPrevious> source,
           params Expression<Func<TPrevious, TProp>>[] expression)
            where TEntity : BaseModel where TProp : ITranslationModel
        => source.ThenInclude(expression[0])
            .ThenInclude(m => m.LanguagesContent.Where(l => l.Language == DefaultLanguage));

        /// <summary>
        /// for get content 
        /// </summary>
        /// <returns></returns>
        public static IIncludableQueryable<TEntity, IEnumerable<TranslationLanguageModel>> ThenIncludeDefaultLanguage<TEntity, TPrevious, TProp>(this IIncludableQueryable<TEntity, IEnumerable<TPrevious>> source,
           params Expression<Func<TPrevious, TProp>>[] expression)
            where TEntity : BaseModel where TProp : ITranslationModel
        => source.ThenInclude(expression[0])
            .ThenInclude(m => m.LanguagesContent.Where(l => l.Language == DefaultLanguage));

        /// <summary>
        /// for get content 
        /// </summary>
        /// <param name="translation"></param>
        /// <returns></returns>
        public static string GetDefaultLanguageContent(this TranslationModel translation)
        {
            if (translation == null) throw new NullReferenceException(nameof(TranslationModel));
            if (!translation.LanguagesContent.Any()) return "";
            return translation.LanguagesContent.FirstOrDefault(m => m.Language == DefaultLanguage)?.Content;
        }

        /// <summary>
        /// for save content  
        /// </summary>
        /// <returns></returns>
        public static async Task<TranslationModel> SetLanguageContent<T>(this T source,
            Expression<Func<T, TranslationModel>> expression, MyAppContext db, string content,
            Language? languageContent=null) where T : BaseModel
        {
            var language = languageContent ?? DefaultLanguage;
            if (source == null) throw new ArgumentNullException(nameof(source));
            var languageModel = new TranslationLanguageModel { Content = content, Language = language, };
            var translationContent = new TranslationModel();
            if (db.Entry(source).State == EntityState.Detached)
            {
                translationContent.LanguagesContent = new List<TranslationLanguageModel> { languageModel };
                await db.AddAsync(translationContent);
            }
            else
            {
                translationContent = await db.Entry(source)
                     .Reference(expression)
                     .Query()
                     .Include(m => m.LanguagesContent.Where(l => l.Language == language))
                     .FirstOrDefaultAsync();

                // add new translation content
                if (translationContent == null)
                {
                    translationContent = new TranslationModel() { LanguagesContent = new List<TranslationLanguageModel> { languageModel } };
                    await db.AddAsync(translationContent);
                }
                else //add / edit translation language
                {
                    var lang = translationContent.LanguagesContent.FirstOrDefault(m => m.Language == language);
                    if (lang == null) translationContent.LanguagesContent.Add(languageModel);
                    else lang.Content = content;
                }
            }

            return translationContent;
        }
    }
}
