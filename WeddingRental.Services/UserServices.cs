using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRental.Data;
using WeddingRental.Models.User;
using WeddingRental.WebMVC.Models;

namespace WeddingRental.Services
{
    public class UserServices
    {
        private readonly Guid _userId;
        public UserServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(CreateUser model)
        {
            var entity =
                   new User()
                   {
                       OwnerId = _userId,
                       Address = model.Address,
                       UserName = model.UserName,
                     //Rentals
                   };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Userss.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Userss
                    
                    .Select(
                        e => new UserListItem
                        {
                            UserId = e.UserId,
                            UserName = e.UserName,
                            Address = e.Address,
                            Rentals =  e.Rentals

                        });
                return query.ToArray();
            }
        }

        public UserDetails GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Userss
                        .Single(e => e.UserId == id && e.OwnerId == _userId);
                return
                    new UserDetails
                    {
                        UserId = entity.UserId,
                        UserName = entity.UserName,
                        Address = entity.Address

                    };
            }
        }

        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Userss
                    .Single(e => e.UserId == model.UserId && e.OwnerId == _userId);

                entity.Address = model.Address;
                entity.UserName = model.UserName;
             
                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteUser(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Userss
                        .Single(e => e.UserId == Id&&e.OwnerId==_userId);

                ctx.Userss.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
