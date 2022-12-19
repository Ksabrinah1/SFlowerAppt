using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using SapphireApp.Data;
using SapphireApp.Models;
using SapphireApp.ViewModels;

namespace SapphireApp.Controllers
{
    public class ProductController : Controller
    {
        //Give access to the db context
        SFlowerDbContext _context;

        public ProductController(SFlowerDbContext context)
        {
            _context = context;
        }
        //This is our get. To get orders from our db
        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.Products;
            return View(products);
        }

        //Login
        //[Authorize]

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Product> products = _context.Products;
            List<string> productCategory = new List<string>();
            SelectList selects = new SelectList(productCategory);
            productCategory.Add("Potted");
            productCategory.Add("Arrangement");
            ViewBag.ProductCategory = selects;

         
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            //check if data is valid
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            //then add new product to db
            _context.Products.Add(product);
            //save change to the db
            _context.SaveChanges();
            //back to the product collection with the new product saved to the db
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ////check to see if id came in
            if (id == 0)
            {
                return NotFound();
            }
            //IEnumerable<Product> products = _context.Products;
            //get product from the database
            Product product = _context.Products.SingleOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
            //Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            //if(product == null)
            //{
            //    return Json(product);
            //}
            //ProductEditVM productEditVM = new ProductEditVM()
            //{
            //    Id = product.Id,
            //    ProductName = product.ProductName,
            //    Category = product.Category,
            //    Price = product.Price,
            //    ProductImage = product.ProductImage,
            //};
            //return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            //pull product object from db
            Product product1 = _context.Products.SingleOrDefault(x => x.Id == product.Id);

            //map the properties of the paramater product to the product we pulled from the database
            product1.ProductName = product.ProductName;
            product1.Category = product.Category;
            product1.Color = product.Color;
            product1.Price = product.Price;
            product1.Description = product.Description;
            product1.ProductImage = product.ProductImage;
            //update the database
            _context.Update(product1);
            //save the changes
            _context.SaveChanges();


            //update - db
            //_context.Update(product);
            // _context.SaveChanges();
            //or update properties with  the information
            //Product p = _context.Products.SingleOrDefault(x => x.Id == product.Id);
            //p.ProductName = product.ProductName;
            //p.Color = product.Color;
            //p.Category = product.Category;
            //p.Price = product.Price;
            //p.Description = product.Description;
            //_context.Update(p);
            //_context.SaveChanges();
            //return View(product);
            //return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Product product = _context.Products.SingleOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Product product = _context.Products.SingleOrDefault(x => x.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Delete(Product product)
        //{
        //    if (product.Id == 0)
        //    {
        //        return NotFound();
        //    }
        //    product = _context.Products.SingleOrDefault(x => x.Id == product.Id);
        //    return RedirectToAction("Index");
        //}
    }
}
