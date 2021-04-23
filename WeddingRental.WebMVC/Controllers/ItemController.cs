using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingRental.Models.Item;
using WeddingRental.Services;

namespace WeddingRental.WebMVC.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index() // displays all the Rentals for the current user
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ItemServices(userId);
            var model = service.GetItems();

            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateItem model) //makes sure the model is valid, grabs the current userId, calls on CreateRental, and returns the user back to the index view
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateItemService();

            if (service.CreateItem(model))
            {
                TempData["SaveResult"] = "Your item was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Item could not be created.");

            return View(model);
        }

        private ItemServices CreateItemService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var itemServices = new ItemServices(userId);
            return itemServices;

        }

        public ActionResult Details(int id)
        {
            var svc = CreateItemService();
            var model = svc.GetItemById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateItemService();
            var detail = service.GetItemById(id);
            var model =
                new ItemEdit
                {
                    ItemId = detail.ItemId,
                    DropoffAddress = detail.DropoffAddress,
                    PickupAddress = detail.PickupAddress

                };
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateItemService();
            var model = svc.GetItemById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateItemService();

            service.DeleteItem(id);

            TempData["SaveResult"] = "Your item was deleted";

            return RedirectToAction("Index");
        }

   

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, ItemEdit model)
    {
        if (!ModelState.IsValid)

            return View(model);

        if (model.ItemId != id)
        {
            ModelState.AddModelError("", "Id Mismatch");
            return View(model);
        }


        var service = CreateItemService();

        if (service.UpdateItem(model))
        {
            TempData["SaveResult"] = "Your Rental was updated.";
            return RedirectToAction("Index");
        }

        ModelState.AddModelError("", "Your rental could not be updated.");
        return View(model);
    }

  }

}