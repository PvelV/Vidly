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

            var vm = new MovieFormViewModel(movie, db.Genres.GetAll());
            return View("MovieForm", vm);
        }

        public ActionResult Create()
        {
            var vm = new MovieFormViewModel ( db.Genres.GetAll() );
            return View("MovieForm", vm);
        }

        public ActionResult Delete(int id)
        {
            db.Movies.Remove(db.Movies.Get(id));
            db.Complete();

            return RedirectToAction("Index", "Movies");
        }

        [HttpPost]
        public ActionResult Save(MovieFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Genres = db.Genres.GetAll();
                return View("MovieForm", vm);
            }

            if (vm.Id == 0)
            {
                vm.DateAdded = DateTime.Now;
                db.Movies.Add(vm.ToMovie());
            }
            else
            {
                var movieInDb = db.Movies.Get(vm.Id.Value);

                movieInDb.Name = vm.Name;
                movieInDb.ReleaseDate = vm.ReleaseDate.Value;
                movieInDb.DateAdded = vm.DateAdded.Value;
                movieInDb.GenreId = vm.GenreId.Value;
                movieInDb.NumberInStock = vm.NumberInStock.Value;
            }

            db.Complete();

            return RedirectToAction("Index", "Movies");
        }
    }
}