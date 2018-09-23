using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 0, FirstName = "John", LastName = "Doe" },
                new Customer { Id = 1, FirstName = "Pavel", LastName = "Vaverka" }
            };

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = new Customer { FirstName = "John", LastName = "Doe" };
            return View(customer);
        }
    }
}