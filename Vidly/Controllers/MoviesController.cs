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

        //Get: Movies/Random
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+ "/" + month);
        }
    }
}