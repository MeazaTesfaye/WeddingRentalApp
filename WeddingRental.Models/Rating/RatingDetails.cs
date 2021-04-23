using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRental.Models.Rating
{
   public class RatingDetails
    {
        public int? RaterId { get; set; }

         [ForeignKey(nameof(Item))]
          public int? ItemId { get; set; }
        [Required]
        public double Star { get; set; }
        [Required]
        public string Text { get; set; }
        public string UserName { get; set; }
    }
}
