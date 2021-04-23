using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingRental.Models.Rating;
using WeddingRental.Services;
using WeddingRental.WebMVC.Models;

namespace WeddingRental.WebMVC.Controllers
{
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index() // displays all the Rentals for the current user
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingServices(userId);
            var model = service.GetRatings();

            return View(model);
        }
    

    public ActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CreateRating model) //makes sure the model is valid, grabs the current userId, calls on CreateRental, and returns the user back to the index view
    {
        if (!ModelState.IsValid)
            return View(model);

        var service = CreateRatingService();

        if (service.RatingCreate(model))
        {
            TempData["SaveResult"] = "Your Rating was created.";
            return RedirectToAction("Index");
        };

        ModelState.AddModelError("", "Rating could not be created.");

        return View(model);
    }

        private RatingServices CreateRatingService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var ratingService = new RatingServices(userId);
            return ratingService;

        }


        public ActionResult Details(int id)
        {
            var svc = CreateRatingService();
            var model = svc.GetRatingById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRatingService();
            var detail = service.GetRatingById(id);
            var model =
                new RatingEdit
                {
                    Star = detail.Star,
                    Text = detail.Text,
                    

                };
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRatingService();
            var model = svc.GetRatingById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRatingService();

            service.DeleteRating(id);

            TempData["SaveResult"] = "Your item was deleted";

            return RedirectToAction("Index");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RatingEdit model)
        {
            if (!ModelState.IsValid)

                return View(model);

            if (model.RaterId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }


            var service = CreateRatingService();

            if (service.UpdateRating(model))
            {
                TempData["SaveResult"] = "Your rating was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your rating could not be updated.");
            return View(model);
        }


    }
}