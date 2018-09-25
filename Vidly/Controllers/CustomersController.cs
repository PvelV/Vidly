using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Repository;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private readonly IUnitOfWork db;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public ActionResult Index()
        {
            var customers = db.Customers.GetAll();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = db.Customers.Get(id);

            return View(customer);
        }
    }
}