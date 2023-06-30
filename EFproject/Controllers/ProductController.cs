using EFproject.Data;
using EFproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFproject.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
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
        [HttpPost]
        public IActionResult Add([Bind("Name", "Description", "Category", "Price")] ProductModel product)
        {
            //if (ModelState.IsValid)
            //{
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            //}
            return View(product);
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
        public IActionResult Edit([Bind("Id", "Name", "Description", "Category", "Price")] ProductModel product) 
        {
        _db.Products.Update(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
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
