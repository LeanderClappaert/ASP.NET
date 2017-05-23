using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        [Route("Customers")]
        public ActionResult Customers()
        {
            var customerlist = _context.Customers.Include(c => c.MembershipType).ToList();
            var viewModel = new CustomerViewModel { CustomerList = customerlist};
            return View(viewModel);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var customerlist = _context.Customers.Include(c => c.MembershipType).ToList();

            if (customerlist == null)
            {
                return HttpNotFound();
            }
            else
            {
                var customer = customerlist.Find(c => c.Id == id);

                var viewModel = new CustomerDetailViewModel
                {
                    Name = customer.Name,
                    MembershipType = customer.MembershipType,
                    Id = id,
                    BirthDate = customer.Birthdate
                };

                return View(viewModel);
            }
        }
    }
}