using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Models.DTOs;
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


        public IHttpActionResult GetCustomers()
        {
            return Ok(db.Customers.GetAll().Select(Mapper.Map<CustomerDTO>));
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = db.Customers.Get(id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<CustomerDTO>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<Customer>(customerDto);

            db.Customers.Add(customer);
            db.Complete();

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), Mapper.Map<CustomerDTO>(customer));
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = db.Customers.Get(id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);
            db.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = db.Customers.Get(id);

            if (customerInDb == null)
                return BadRequest();

            db.Customers.Remove(customerInDb);
            db.Complete();

            return Ok();
        }

    }
}
