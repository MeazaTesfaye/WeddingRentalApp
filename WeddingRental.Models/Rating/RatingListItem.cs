using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRental.Models.Rating
{
   public class RatingListItem
    {
        public int RaterId { get; set; }
        public Guid OwnerId { get; set; }

        // [ForeignKey(nameof(Item))]
        //  public int ItemId { get; set; }
        [Required]
        public double Star { get; set; }
        [Required]
        public string Text { get; set; }
       // public string UserName { get; set; }
    }
}
