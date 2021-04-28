using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingRental.Models.User;
using WeddingRental.Services;

namespace WeddingRental.WebMVC.Controllers
{
    public class UserController : Controller
    {
        
        // GET: User
        public ActionResult Index() // displays all the Rentals for the current user
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserServices(userId);
            var model = service.GetUsers();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateUser model) //makes sure the model is valid, grabs the current userId, calls on CreateRental, and returns the user back to the index view
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateUserService();

            if (service.CreateUser(model))
            {
                TempData["SaveResult"] = "user was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "User could not be created.");

            return View(model);

        }

        private UserServices CreateUserService()
        {

            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var userService = new UserServices(userId);
            return userService;

        }

        public ActionResult Details(int id)
        {
            var svc = CreateUserService();
            var model = svc.GetUserById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateUserService();
            var detail = service.GetUserById(id);
            var model =
                new UserEdit
                {
                    Address = detail.Address,
                    UserName = detail.UserName,
                };
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateUserService();
            var model = svc.GetUserById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateUserService();

            service.DeleteUser(id);

            TempData["SaveResult"] = "User was deleted";

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserEdit model)
        {
            if (!ModelState.IsValid)

                return View(model);

            if (model.UserId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }


            var service = CreateUserService();

            if (service.UpdateUser(model))
            {
                TempData["SaveResult"] = "User was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", " User could not be updated.");
            return View(model);
        }

    }
}