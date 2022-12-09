using DotNetCore_MultiLanguageSample.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_MultiLanguageSample.Configuration
{
    public static class RegisterService
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // db context
            services.AddDbContext<MyAppContext>(option =>
            {
                option.UseInMemoryDatabase("MultiLanguage_DB");
            });
            services.AddScoped<MyAppContext>();
            // services
        }
    }
}
