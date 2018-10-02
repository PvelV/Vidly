using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Repository;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly IUnitOfWork db;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }


        public IEnumerable<Customer> GetCustomers()
        {
            return db.Customers.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            var customer = db.Customers.Get(id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            db.Customers.Add(customer);
            db.Complete();
            return customer;
        }

        [HttpPut]
        public Customer UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = db.Customers.Get(id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.FirstName = customerInDb.FirstName;
            customerInDb.LastName = customerInDb.LastName;
            customerInDb.MembershipTypeId = customerInDb.MembershipTypeId;
            customerInDb.IsSubscribed = customerInDb.IsSubscribed;
            customerInDb.BirthDate = customerInDb.BirthDate;

            db.Complete();

            return customer;
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = db.Customers.Get(id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Customers.Remove(customerInDb);
            db.Complete();                      
        }

    }
}
