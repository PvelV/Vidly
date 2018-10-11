using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Vidly.Models;
using Vidly.Models.DTOs;
using Vidly.Repository;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private readonly IUnitOfWork db;

        public RentalsController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }


        // POST: api/Rentals
        [HttpPost]
        [ResponseType(typeof(NewRentalDTO))]
        public IHttpActionResult CreateRental(NewRentalDTO rentalDTO)
        {
            var customer = db.Customers.Get(rentalDTO.CustomerId);

            var movies = db.Movies.Find(m => rentalDTO.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                db.Rentals.Add(rental);
            }
            db.Complete();

            return Ok();
        }
    }
}