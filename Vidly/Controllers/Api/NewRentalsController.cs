using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.Models.IdentityModels;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context= new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);

            if (newRental.MovieIds.Count == 0)
                return BadRequest("No movie Ids have been given");

            if (customer == null)
                return BadRequest("Customer Id is not Valid.");

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or MovieIds are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("This movie is currently not available");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                    
                };
                _context.Rentals.Add(rental);

            }

            _context.SaveChanges();

            return Ok();
        }

    }
}
