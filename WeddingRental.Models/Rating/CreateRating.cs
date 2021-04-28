using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRental.Models.Rating
{
   public class CreateRating
    {
         public int? ItemId { get; set; }
       
        public double Star { get; set; }
      
        public string Text { get; set; }
        public string UserName { get; set; }
    }
}
