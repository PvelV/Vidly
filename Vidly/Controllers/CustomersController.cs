using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Repository;
using Vidly.ViewModels;

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

        [HttpGet]
        public ActionResult Create()
        {
            var membershipTypes = db.MembershipTypes.GetAll();
            var viewModel = new CreateCustomerViewModel { Customer = new Customer(), MembershipTypes = membershipTypes };
           
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateCustomerViewModel vm)
        {
            db.Customers.Add(vm.Customer);
            db.Complete();

            return RedirectToAction("Index", "Customers");
        }
    }
}