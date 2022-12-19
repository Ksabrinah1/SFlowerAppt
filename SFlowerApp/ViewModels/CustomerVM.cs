using SapphireApp.Data;
using SapphireApp.Models;

namespace SapphireApp.ViewModels
{
    public class CustomerVM
    {
        private readonly SFlowerDbContext _context;
        
        private List<Customer> _customerList;

        public CustomerVM(SFlowerDbContext context)
        {
            _context = context;
            _customerList = _context.Customers.ToList();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Order Order { get; set; }
        public string ContactPhone { get; set; }
       
    }
}
