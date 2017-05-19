using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> customerlist = new List<Customer>();

        public CustomersController()
        {
            customerlist.Add(new Customer { Name = "John Smith", Id = 1 });
            customerlist.Add(new Customer { Name = "Mary Williams", Id = 2 });
        }

        // GET: Customers
        [Route("Customers")]
        public ActionResult Customers()
        {
            var viewModel = new CustomerViewModel
            {
                CustomerList = customerlist
            };

            return View(viewModel);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            string customerName = "";

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