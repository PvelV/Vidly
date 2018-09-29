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

        public ActionResult Edit(int id)
        {
            var movie = db.Movies.Get(id);

            if (movie == null)
                return HttpNotFound();

            var vm = new MovieFormViewModel { Movie = movie, Genres = db.Genres.GetAll() };
            return View("MovieForm", vm);
        }

        public ActionResult Create()
        {
            var vm = new MovieFormViewModel { Movie = new Movie(), Genres = db.Genres.GetAll() };
            return View("MovieForm", vm);
        }

        public ActionResult Delete(int id)
        {
            db.Movies.Remove(db.Movies.Get(id));
            db.Complete();

            return RedirectToAction("Index", "Movies");
        }

        [HttpPost]
        public ActionResult Save(MovieFormViewModel movieFormVM)
        {
            if (movieFormVM.Movie.Id == 0)
            {
                movieFormVM.Movie.DateAdded = DateTime.Now;
                db.Movies.Add(movieFormVM.Movie);
            }
            else
            {
                var movieInDb = db.Movies.Get(movieFormVM.Movie.Id);

                movieInDb.Name = movieFormVM.Movie.Name;
                movieInDb.ReleaseDate = movieFormVM.Movie.ReleaseDate;
                movieInDb.DateAdded = movieFormVM.Movie.DateAdded;
                movieInDb.GenreId = movieFormVM.Movie.GenreId;
                movieInDb.NumberInStock = movieFormVM.Movie.NumberInStock;
            }

            db.Complete();

            return RedirectToAction("Index", "Movies");
        }
    }
}