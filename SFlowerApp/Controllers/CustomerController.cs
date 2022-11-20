using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using SapphireApp.Data;
using SapphireApp.Models;

namespace SapphireApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly SFlowerDbContext _context;

        public CustomerController(SFlowerDbContext context)
        {
            _context = context;
        }
        //default index, always a get method. Here, we're just getting a collection of customers
        public IActionResult Index()
        {
            //get the customers
            IEnumerable<Customer> customers = _context.Customers;
            return View(customers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            //checking if model is valid
            if (!ModelState.IsValid)
            {
                //send back on fail
                return View(customer);
            }
           //then add new customer to db
           _context.Customers.Add(customer);
            //save change to the db
           _context.SaveChanges();
            //back to the list of customer  
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //first thing check to see if anything came in
            if(id == 0)
            {
                return NotFound();
            }
            //pull customer id from db
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            //check model
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
                _context.Update(customer);
                _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Details is just a get method
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
    }
       
}
