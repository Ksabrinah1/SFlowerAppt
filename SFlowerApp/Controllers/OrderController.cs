using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapphireApp.Data;
using SapphireApp.Models;
using System.Collections.Generic;

namespace SapphireApp.Controllers
{
    public class OrderController     : Controller
    {
        //set a field
        private SFlowerDbContext _context;
        //set a constructor
        public OrderController(SFlowerDbContext context)
        {
            _context = context; 
        }

        public IActionResult Index()    
        {
            IEnumerable<Order> orders = _context.Orders;
            return Json(orders);
        }
    }
}
