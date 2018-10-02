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
    public class MoviesController : ApiController
    {
        private readonly IUnitOfWork db;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }


        public IHttpActionResult GetMovies()
        {
            return Ok(db.Movies.GetAll().Select(Mapper.Map<MovieDTO>));
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = db.Movies.Get(id);

            if (movieInDb == null)
                return NotFound();

            return Ok(Mapper.Map<MovieDTO>(movieInDb));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<Movie>(movieDto);

            db.Movies.Add(movie);
            db.Complete();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), Mapper.Map<MovieDTO>(movie));
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = db.Customers.Get(id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);
            db.Complete();

            return Ok();
        }
    }
}
