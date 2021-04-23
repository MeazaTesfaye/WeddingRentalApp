using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}