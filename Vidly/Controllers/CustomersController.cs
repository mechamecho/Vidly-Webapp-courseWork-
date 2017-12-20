using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        //To initialize the ApplicationDbContext 
        public CustomersController()
        {
            _context=new ApplicationDbContext();
            
        }

        //To dispose of the ApplicationDbContext instance
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            //Grabs the customers from the Database, we called the ToList() method to immediately execute
            //the query
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //The query will be immediately executed because of the SingleOrDefault extension method
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}