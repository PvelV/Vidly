using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Repository;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IUnitOfWork db;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public ActionResult Index()
        {
            var movies = db.Movies.GetAll();

            return View(movies);
        }
  

        public ActionResult Details(int id)
        {
            var movie = db.Movies.Get(id);
            return View(movie);
        }
    }
}