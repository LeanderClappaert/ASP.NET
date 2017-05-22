using System.Collections.Generic;
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
            string customerName = "";
            var customerlist = _context.Customers.ToList();

            foreach (var customer in customerlist)
            {
                if (customer.Id == id)
                {
                    customerName = customer.Name;
                    break;
                }
            }

            if (customerName == "")
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new CustomerDetailViewModel
                {
                    Name = customerName,
                    Id = id
                };

                return View(viewModel);
            }
        }
    }
}