using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRental.Models.Rating;
using WeddingRental.Models.User;

namespace WeddingRental.Models.Item
{
   public class ItemDetails
    {

        public int ItemId { get; set; }

        // [ForeignKey(nameof(User))]
         //public int UserId { get; set; }
       

        public double Price { get; set; }
       // [ForeignKey(nameof(Rating))]
        public double Star { get; set; }
        public string PickupAddress { get; set; }
        
        public string DropoffAddress { get; set; }

        public virtual RatingListItem Ratings { get; set; }

        public virtual UserListItem Users { get; set; }
    }

}

