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

        public ActionResult Edit(int id)
        {
            var customer = db.Customers.Get(id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel { Customer = customer, MembershipTypes = db.MembershipTypes.GetAll() };

            return View("CustomerForm", viewModel);
        }

        public ActionResult CustomerForm()
        {
            var viewModel = new CustomerFormViewModel { Customer = new Customer(), MembershipTypes = db.MembershipTypes.GetAll() };

            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            db.Customers.Remove(db.Customers.Get(id));
            db.Complete();
            return RedirectToAction("Index", "Customers");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel vm)
        {
            if (!ModelState.IsValid)
                return View("CustomerForm", vm);

            if (vm.Customer.Id == 0)
            {
                db.Customers.Add(vm.Customer);
            }
            else
            {
                var customerInDb = db.Customers.Get(vm.Customer.Id);
                customerInDb.FirstName = vm.Customer.FirstName;
                customerInDb.LastName= vm.Customer.LastName;
                customerInDb.BirthDate= vm.Customer.BirthDate;
                customerInDb.IsSubscribed= vm.Customer.IsSubscribed;
                customerInDb.MembershipType= vm.Customer.MembershipType;
            }

            db.Complete();

            return RedirectToAction("Index", "Customers");
        }
    }
}