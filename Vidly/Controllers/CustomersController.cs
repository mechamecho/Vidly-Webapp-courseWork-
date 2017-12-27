﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using System.Runtime.Caching;
using Vidly.Models.IdentityModels;
using Vidly.ViewModels;

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

        //We don't need the customer's list anymore, because the api provides it to the 
        //Client
        public ViewResult Index()
        {
            //Removing Caching because it can lead to problems with EF and 
            //is only encouraged for view related objects

            ////Genre field must be static, otherwise we need to instantiate 
            ////MemoryItem instance
            //if (MemoryCache.Default[MemoryCacheItems.Genre] == null)
            //    MemoryCache.Default["Genres"] = _context.Genres.ToList();

            //var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

            return View();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel= new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            


            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Details(int id)
        {
            //The query will be immediately executed because of the SingleOrDefault extension method
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel=new CustomerFormViewModel
            {
                Customer=customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}