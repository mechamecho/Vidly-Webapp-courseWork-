using System;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {   
            var movie = new Movie() {Name = "Shrek!"};
//            return View(movie);
//            return HttpNotFound();
//            return new EmptyResult();
            return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        }

        public ActionResult Edit(int movieId)
        {
            return Content("id=" + movieId);
        }

        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }

        //Get: Movies/Random
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }
    }
}