using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRental.Data;
using WeddingRental.Models.Rating;
using WeddingRental.WebMVC.Models;

namespace WeddingRental.Services
{
  public  class RatingServices
    {
        private readonly Guid _userId;
        public RatingServices(Guid userId)
        {
            _userId = userId;
        }

        public bool RatingCreate(CreateRating model)
        {
            var entity =
                   new Rating()
                   {
                       OwnerId = _userId,
                       ItemId = model.ItemId,
                       UserName = model.UserName,
                       Star = model.Star,
                       Text = model.Text

                       
                   };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RatingListItem> GetRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Ratings
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e => new RatingListItem
                        {
                            RaterId = e.RaterId,
                            Star = e.Star,
                            Text = e.Text,
                            UserName = e.UserName,
                           ItemId = e.ItemId
                            

                        });
                return query.ToArray();
            }
        }

        public RatingDetails GetRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.OwnerId == _userId);
                return
                    new RatingDetails
                    {
                        //ItemId = entity.ItemId,
                        Star = entity.Star,
                        Text = entity.Text,
                        UserName = entity.UserName
                        

                    };
            }
        }

        public bool DeleteRating(int raterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.RaterId == raterId && e.OwnerId == _userId);

                ctx.Ratings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateRating(RatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ratings
                    .Single(e => e.RaterId == model.RaterId && e.OwnerId == _userId);

                
                //entity.ItemId = model.ItemId;
                entity.Star = model.Star;
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }
    }
 }

