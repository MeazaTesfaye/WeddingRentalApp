using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRental.Data;
using WeddingRental.Models.Item;
using WeddingRental.WebMVC.Models;

namespace WeddingRental.Services
{
   public class ItemServices
    {
        private readonly Guid _userId;
        public ItemServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateItem(CreateItem model)
        {
            var entity =
                   new Item()
                   {
                       OwnerId = _userId,
                       Price = model.Price,
                       DropoffAddress = model.DropoffAddress,
                       PickupAddress = model.PickupAddress
                       
                       //UserId = model.UserId,
                   };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ItemListItem> GetItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Items
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e => new ItemListItem
                        {
                           
                            ItemId = e.ItemId,
                            Price = e.Price,
                            PickupAddress = e.PickupAddress,
                            DropoffAddress = e.DropoffAddress

                        });
                return query.ToArray();
            }
        }

        public ItemDetails GetItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Items
                        .Single(e => e.ItemId == id && e.OwnerId == _userId);
                return
                    new ItemDetails
                    {
                        ItemId = entity.ItemId,
                        PickupAddress = entity.PickupAddress,
                         DropoffAddress = entity.DropoffAddress,
                        Price = entity.Price,
                        //Star = entity.Star

                    };
            }
        }

        public bool DeleteItem(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Items
                        .Single(e => e.ItemId == itemId && e.OwnerId == _userId);

                ctx.Items.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateItem(ItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Items
                    .Single(e => e.ItemId == model.ItemId && e.OwnerId == _userId);

                entity.ItemId = model.ItemId;
                entity.DropoffAddress = model.DropoffAddress;
                entity.PickupAddress = model.PickupAddress;
               // entity.Brand = model.Brand;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
