using DotNetCore_MultiLanguageSample.Data.Models;
using DotNetCore_MultiLanguageSample.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_MultiLanguageSample.Data.Context
{
    public class MyAppContext:DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options):base(options) { }
        public MyAppContext(){}

        //     **********************

        public DbSet<TranslationLanguageModel> TranslationLanguages { get; set; }
        public DbSet<TranslationModel> Translations { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CartModel> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
