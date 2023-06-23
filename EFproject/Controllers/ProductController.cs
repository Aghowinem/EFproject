using EFproject.Data;
using Microsoft.AspNetCore.Mvc;

namespace EFproject.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var Products = _db.Products.ToList();
            ViewData["products"] = Products;
            return View();
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }
           var products = _db.Products.ToList().Find(x => x.Id == id);
            ViewData["products"] = products;
           return View(products);
        }
    }
}
