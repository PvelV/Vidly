using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie { Id = 0,  Name = "Test Movie 1" },
                new Movie { Id = 1,  Name = "Test Movie 2" }
            };

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = new Movie { Name = "Test Movie 1" } ;
            return View(movie);
        }
    }
}