using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Productreview.Models;

namespace Productreview.Controllers
{
    public class ProductcustomController : Controller
    {
        private  AppDbContext db;

        public ProductcustomController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            ViewBag.data = "Product Added Successfully";
            return View();
        }

        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }
        public IActionResult Edit(int? id)
        {
            var data = db.Products.Find(id);

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Product p)
        {
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var data = db.Products.Find(id);
            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            var data = db.Products.Find(id);

            return View(data);
        }
    }
}
