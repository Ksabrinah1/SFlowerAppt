using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapphireApp.Data;
using SapphireApp.Models;
using System.Collections.Generic;
using static NuGet.Packaging.PackagingConstants;

namespace SapphireApp.Controllers
{
    public class OrderController : Controller
    {
        //set a field
        private readonly SFlowerDbContext _context;
        //set a constructor
        public OrderController(SFlowerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Order> orders = _context.Orders.Include(o => o.Customer);
            return View(orders);
        }
        [HttpGet]
        public IActionResult Create()
        {
                      
            return View(); 
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
            //check if data passed in is valid
            if (!ModelState.IsValid)
            {
                return View(order);
                //return NotFound();
            }

            //return Json(order);
            //if valid add it to the collection of orders
            _context.Orders.Add(order);
            //save it to the data
            _context.SaveChanges();
            //redirect user to the collection of orders
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            //IEnumerable<Order> orders = _context.Orders;
            Order order = _context.Orders.SingleOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        [HttpPost]
        public IActionResult Edit(Order model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            //pull order object from db
             Order order = _context.Orders.SingleOrDefault(x => x.Id == model.Id);

            //map the properties of the parameter order with the order we pulled from the db

            order.ShipDate = model.ShipDate;
            order.OrderDate = model.OrderDate;
            order.ShipCity = model.ShipCity;
            order.ShipAddress = model.ShipAddress;
            order.ShipName = model.ShipName;
            order.ShipCountry = model.ShipCountry;
            order.ShipZipCode = model.ShipZipCode;
            order.ContactPhone = model.ContactPhone;
            order.CustomerId = model.CustomerId;
            order.ShipRegion = model.ShipRegion;

            //update the db
            _context.Update(order);
            //save the changes
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        
    }
}