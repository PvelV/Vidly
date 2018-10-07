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
            //      var customers = db.Customers.GetAll();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index");

            return View("ReadOnlyIndex");

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

            var viewModel = new CustomerFormViewModel(customer, db.MembershipTypes.GetAll());
            return View("CustomerForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            var viewModel = new CustomerFormViewModel(db.MembershipTypes.GetAll());
            return View("CustomerForm", viewModel);
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

            if (vm.Id == 0)
            {
                db.Customers.Add(vm.ToCustomer());
            }
            else
            {
                var customerInDb = db.Customers.Get(vm.Id.Value);
                customerInDb.FirstName = vm.FirstName;
                customerInDb.LastName = vm.LastName;
                customerInDb.BirthDate = vm.BirthDate;
                customerInDb.IsSubscribed = vm.IsSubscribed;
                customerInDb.MembershipTypeId = vm.MembershipTypeId.Value;
            }

            db.Complete();

            return RedirectToAction("Index", "Customers");
        }
    }
}