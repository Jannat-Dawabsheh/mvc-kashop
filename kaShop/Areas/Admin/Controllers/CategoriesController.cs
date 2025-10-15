using kaShop.Data;
using kaShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace kaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDbContext context=new ApplicationDbContext();
        public IActionResult Index()
        {
            var cats = context.Categories.ToList();
            return View(cats);
        }

        public IActionResult Create()
        {
            return View(new Category());
        }

        public IActionResult Store(Category request)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", request);
            }
            context.Categories.Add(request);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Edit(int id)
        {
            var cats = context.Categories.Find(id);
            
            return View(cats);

        }

        public IActionResult Update(Category request)
        {
            if (!ModelState.IsValid)
            {
                return View("edit", request);
            }
            var cats = context.Categories.Find(request.Id);
            cats.Name= request.Name;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Remove(int id)
        {
            var cats=context.Categories.Find(id);
            context.Categories.Remove(cats);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
