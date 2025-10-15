using kaShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace kaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        ApplicationDbContext context=new ApplicationDbContext();
        public IActionResult Index()
        {
            var cats = context.Categories.ToList();
            return View(cats);
        }
    }
}
