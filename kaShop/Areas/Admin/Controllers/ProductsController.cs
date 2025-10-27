using kaShop.Data;
using kaShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace kaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        ApplicationDbContext context=new ApplicationDbContext();
        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories=context.Categories.ToList();
            return View(new Product());
        }

        public IActionResult Store(Product request,IFormFile file)
        {
            if(file!=null && file.Length >0)
            {
                var fileName = Guid.NewGuid().ToString();
                fileName += Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"WWWroot\images", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                }
                request.Image = fileName;

                context.Products.Add(request);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View("Create", request);
        }


        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            ViewBag.Categories = context.Categories.ToList();
            return View(product);


        }
        public IActionResult Remove(int id)
        {
            var product=context.Products.Find(id);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"WWWroot\images", product.Image);
            System.IO.File.Delete(filePath);
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }
    }
}
