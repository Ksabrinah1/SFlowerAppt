using Microsoft.AspNetCore.Mvc;
using SapphireApp.Data;
using SapphireApp.Models;

namespace SapphireApp.Controllers
{
    public class OrderDetailsController : Controller
    {
        private SFlowerDbContext _dbContext;

        public OrderDetailsController(SFlowerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<OrderDetail> orderDetails = _dbContext.OrderDetails;
            return Json(orderDetails);
        }
    }
}
