using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRental.Data;
using WeddingRental.Models.User;

namespace WeddingRental.Services
{
    public class UserServices
    {
        private readonly Guid _userId;
        public RentalService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(CreateUser model)
        {
            var entity =
                   new User()
                   {
                       OwnerId = _userId,
                       RentalId = model.RentalId,
                       //UserId = model.UserId,
                       //ItemId = model.ItemId,
                       RentalDate = model.RentalDate,
                       ReturnDate = model.ReturnDate


                   };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Rentals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
