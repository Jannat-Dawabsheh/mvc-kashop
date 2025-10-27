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

        [ValidateAntiForgeryToken]
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
            ViewBag.Categories = context.Categories.ToList();

            return View("Create", request);
        }


        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            ViewBag.Categories = context.Categories.ToList();
            return View(product);


        }

        public IActionResult Update(Product request, IFormFile? file)
        {
            var product = context.Products.Find(request.Id);
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Quantity = request.Quantity;
            product.CategoryId = request.CategoryId;

            if (file != null && file.Length > 0)
            {
                var oldfilePath = Path.Combine(Directory.GetCurrentDirectory(), @"WWWroot\images", product.Image);
                System.IO.File.Delete(oldfilePath);
                var fileName = Guid.NewGuid().ToString();
                fileName += Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"WWWroot\images", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                }
                product.Image = fileName;

            }

            context.SaveChanges();
            return RedirectToAction(nameof(Index));
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
