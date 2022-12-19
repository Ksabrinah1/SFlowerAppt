using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapphireApp.Data;
using SapphireApp.Models;
using System.Collections.Generic;
using System.Linq;
using static NuGet.Packaging.PackagingConstants;

namespace SapphireApp.Controllers
{
    public class OrderController : Controller
    {
        SFlowerDbContext _context;
        //set a constructor
        public OrderController(SFlowerDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<Order> orders = _context.Orders.Include(o => o.Customer);
            return View(orders);
        }
        //Create
        [HttpGet]
        public IActionResult Create(int CustomerId)
        {  //quick check
            if (CustomerId < 0)
            {
                return NotFound();
            }
            
            Order order = new Order
            {
                CustomerId = CustomerId
            };
            return View(order);
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
           
            //validate order
            if (!ModelState.IsValid) 
            {
                return View(order);
            }

            Order order1 = new Order
            {
                CustomerId = order.CustomerId,
                OrderDate = DateTime.Now,
                ShipDate = DateTime.Now,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipCountry = order.ShipCountry,
                ShipZipCode = order.ShipZipCode,
                ContactPhone = order.ContactPhone,
                Customer = order.Customer,
                OrderDetails = order.OrderDetails,
                ShipRegion = order.ShipRegion,
            };

            //return Json(order);
            //if valid add it to the collection of orders
            _context.Orders.Add(order1);
            //save it 
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
            order.Customer = model.Customer;

            //update the db
            _context.Update(order);
            //save the changes
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        
        //need to work on detail view
        [HttpGet]
        public IActionResult Details(int id)
        {
            Order orders = _context.Orders.SingleOrDefault(o => o.Id == id);
            //validate
            if (orders == null) 
            {
                return NotFound();
            }
            return View(orders);
        }
    }
}
