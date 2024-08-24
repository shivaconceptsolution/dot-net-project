using Microsoft.AspNetCore.Mvc;
using Productreview.Models;

namespace Productreview.Controllers
{
    public class AdminLoginController : Controller
    {
        private AppDbContext db;

        public AdminLoginController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminLogin o)
        {
            var s = (from c in db.AdminLogins where c.Username.Equals(o.Username) && c.Password.Equals(o.Password) select c).FirstOrDefault();
            if (s != null)
            {
                return RedirectToAction("Index", "Productcustom");
            }
            ViewBag.error = "Invalid Userid and password";
            return View();
        }
    }
}
