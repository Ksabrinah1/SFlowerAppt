using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SapphireApp.Data;
using SapphireApp.Models;
using SapphireApp.Models;
using System.Diagnostics;

namespace SFlowerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        SFlowerDbContext _context;

        public HomeController(ILogger<HomeController> logger, SFlowerDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        

        public IActionResult Index()
        {
            IEnumerable<Customer> customers = _context.Customers;
           // return Json(customers);
           return View();
        }

        public IActionResult OrchidCare()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}