using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingRental.Models;
using WeddingRental.Services;

namespace WeddingRental.WebMVC.Controllers
{
    [Authorize] //makes it so that the views are accessible only to logged in users
    public class RentalController : Controller
    {
        // GET: WeddingRental
        public ActionResult Index() // displays all the Rentals for the current user
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RentalService(userId);
            var model = service.GetRentals();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RentalCreate model) //makes sure the model is valid, grabs the current userId, calls on CreateRental, and returns the user back to the index view
        {
            if (!ModelState.IsValid)
                return View(model);
            
                var service = CreateRentalService();

                if (service.CreateRental(model))
                {
                    TempData["SaveResult"] = "Your rental was created.";
                    return RedirectToAction("Index");
                };

                ModelState.AddModelError("", "Rental could not be created.");

                return View(model);
            
        }

        private RentalService CreateRentalService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var rentalService = new RentalService(userId);
            return rentalService;

        }

        public ActionResult Details(int id)
        {
            var svc = CreateRentalService();
            var model = svc.GetRentalById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRentalService();
            var detail = service.GetRentalById(id);
            var model =
                new RentalEdit
                {
                    ItemId =   detail.ItemId,
                    RentalDate = detail.RentalDate,
                    ReturnDate = detail.ReturnDate
                };
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRentalService();
            var model = svc.GetRentalById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRentalService();

            service.DeleteRental(id);

            TempData["SaveResult"] = "Your Rental was deleted";

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RentalEdit model)
        {
            if (!ModelState.IsValid) 
                
                return View(model);

            if (model.ItemId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }


            var service = CreateRentalService();

            if (service.UpdateRental(model))
            {
                TempData["SaveResult"] = "Your Rental was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your rental could not be updated.");
            return View(model);
        }



    }
}

