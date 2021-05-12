using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRental.Data;
using WeddingRental.Models;
using WeddingRental.Models.Item;
using WeddingRental.WebMVC.Models;

namespace WeddingRental.Services
{
    public class RentalService
    {
        private readonly Guid _userId;
        public RentalService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRental(RentalCreate model)
        {
            var entity =
                   new Rental()
                   {
                       OwnerId = _userId,
                       UserId = model.UserId,
                       ItemId = model.ItemId,
                       RentalDate = model.RentalDate,
                       ReturnDate = model.ReturnDate,
                       Price = model.Price,


                   };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Rentals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RentalListItem> GetRentals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Rentals
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e => new RentalListItem
                        {
                            RentalId = e.RentalId,
                            Price = e.Price,
                            UserId = e.UserId,
                            ItemId = e.ItemId,
                            RentalDate = e.RentalDate,
                            ReturnDate = e.ReturnDate

                        });
                return query.ToArray();
            }
        }

        public RentalDetails GetRentalById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rentals   
                        .Single(e => e.RentalId == id && e.OwnerId == _userId);
                return
                    new RentalDetails
                    {
                       RentalId = entity.RentalId,
                       Items = new ItemListItem() { ItemId = entity.Item.ItemId, Star = entity.Item.Star, Price = entity.Item.Price, 
                        PickupAddress = entity.Item.PickupAddress, DropoffAddress = entity.Item.DropoffAddress, UserId = entity.Item.UserId},
                        
                        RentalDate = entity.RentalDate,
                        ReturnDate = entity.ReturnDate,
                        Price = entity.Price

                    };
            }
        }

        public bool UpdateRental(RentalEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rentals
                    .Single(e => e.RentalId == model.RentalId && e.OwnerId == _userId);

                entity.ItemId = model.ItemId;
                entity.UserId = model.UserId;
                entity.Price = model.Price;
                entity.RentalDate = model.RentalDate;
                entity.ReturnDate = model.ReturnDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRental(int rentalId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rentals
                        .Single(e => e.RentalId == rentalId && e.OwnerId == _userId );

                ctx.Rentals.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
