using DotNetCore_MultiLanguageSample.Data.Context;
using DotNetCore_MultiLanguageSample.Infra.TranslationHelper;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_MultiLanguageSample.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyAppContext _context;

        public ProductController(MyAppContext context)
        {
            _context = context;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var products = _context.Products
                .IncludeDefaultLanguage(m => m.Title)
                .IncludeDefaultLanguage(m => m.ShortDescription)
                .ToList();
            return View(products);
        }

    }
}
