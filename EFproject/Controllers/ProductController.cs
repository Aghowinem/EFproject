using EFproject.Data;
using EFproject.Models;
using EFproject.ViewModel;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace EFproject.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ILogger<ProductController> _logger ;
        private readonly IWebHostEnvironment _webHostEnvironment ;
        public ProductController(ILogger<ProductController> logger ,AppDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            
        }
        //GET: /products 
        public IActionResult Index()
        {
            var Products = _db.Products.ToList();
            ViewData["products"] = Products;
            return View();
        }
        
        public IActionResult Products()
        {
            var DisplayProducts = _db.Products.ToList();
            ViewData["DisplayProducts"] = DisplayProducts;
             return View();
        }
        public IActionResult ViewingProduct()
        {
            var DisplayProducts = _db.Products.ToList();
            ViewData["ViewingProducts"] = DisplayProducts;
            return View();
        }
        //GET : /products/id 
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
        //GET : /products/create
        public IActionResult Add() 
        {
            return View();
        }
        // POST: /products/create
        /*[HttpPost]
        public IActionResult Add([Bind("Name", "ProductImage", "Description", "Category", "Price")] ProductModel product)
        {
            //if (ModelState.IsValid){}

            //Insert record
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
 
        }*/
        [HttpPost]
        public IActionResult Add(ProductViewModel vm)
        {
            string stringFileName = UploadFile(vm);
            var product = new ProductModel
            {
                Name = vm.Name,
                ProductImage = stringFileName,
                Description = vm.Description,
                Category = vm.Category,
                Price = vm.Price
            };
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        private string UploadFile(ProductViewModel vm)
        {
            string fileName = null;
            if(vm.ProductImage != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages");
                fileName = Guid.NewGuid().ToString()+"-"+vm.ProductImage.FileName;
                /*fileName = vm.ProductImage.FileName;*/
                string filePath = Path.Combine(uploadDir, fileName);
                vm.ProductImage.CopyTo(new FileStream(filePath, FileMode.Create));
               
            }
            Console.WriteLine("File name is :::::: "+ fileName);
            return fileName;
        }

        // GET: /product/edit/id
        public IActionResult Edit(int? id)
        {
            var product = _db.Products.ToList().Find(p => p.Id == id);
            if (id == null || product == null)
            {
                return View("NotFound");
            }
            else
            {
                ViewData["Product"] = product;
                return View();
            }
        }
        //Post: /product/edit/id
        [HttpPost]
        public IActionResult Edit(ProductViewModel vm, ProductModel model)
        {
            string stringFileName = UploadFile(vm);
            Console.WriteLine("stringFileName isssssssssssss ::: " + stringFileName);
            model.Name = vm.Name;
            model.ProductImage = stringFileName;
            model.Description = vm.Description;
            model.Category = vm.Category;
            model.Price = vm.Price;

            _db.Products.Update(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*public IActionResult Edit([Bind("Id", "Name", "Description", "Category", "Price")] ProductModel product) 
        {
        _db.Products.Update(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }*/
        // Post: /product/delete/id
        [HttpPost]
        public IActionResult Delete(int? id) 
        {
            var Product = _db.Products.ToList().FirstOrDefault(p => p.Id == id);
            _db.Products.Remove(Product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
