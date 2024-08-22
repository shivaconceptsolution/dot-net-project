using Microsoft.AspNetCore.Mvc;
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

    }
}
