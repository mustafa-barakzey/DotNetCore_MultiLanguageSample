using DotNetCore_MultiLanguageSample.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCore_MultiLanguageSample.Data.Seed
{
    public class ProductMapping : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.HasKey(m => m.Id);
            
            //var title = new List<TranslationLanguageModel>() { new("IPhone 13 pro") };
            //var shortDescription = new TranslationModel()
            //{
            //    LanguagesContent = new List<TranslationLanguageModel>() { new("In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.") }
            //};
            //var longDescription = new TranslationModel()
            //{
            //    LanguagesContent = new List<TranslationLanguageModel>()
            //    {
            //        new(
            //            "The Lorem ipsum text is derived from sections 1.10.32 and 1.10.33 of Cicero's 'De finibus bonorum et malorum'.[7][8] The physical source may have been the 1914 Loeb Classical Library edition of De finibus, where the Latin text, presented on the left-hand (even) pages, breaks off on page 34 with \"Neque porro quisquam est qui do-\" and continues on page 36 with \"lorem ipsum ...\", suggesting that the galley type of that page was mixed up to make the dummy text seen today.[1]\r\n\r\nThe discovery of the text's origin is attributed to Richard McClintock, a Latin scholar at Hampden–Sydney College. McClintock connected Lorem ipsum to Cicero's writing sometime before 1982 while searching for instances of the Latin word consectetur, which was rarely used in classical literature.[2] McClintock first published his discovery in a 1994 letter to the editor of Before & After magazine, contesting the editor's earlier claim that Lorem ipsum held no meaning.[2]\r\n\r\nThe relevant section of Cicero as printed in the source is reproduced below with fragments used in Lorem ipsum highlighted. Letters in brackets were added to Lorem ipsum and were not present in the source text: ")
            //    }
            //};
           
            //var model = new ProductModel()
            //{
            //    Title = new TranslationModel()
            //    {
            //        LanguagesContent = title
            //    },
            //    ShortDescription = shortDescription,
            //    LongDescription = longDescription,
            //};
        }
    }
}
