using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRental.Models.Item;

namespace WeddingRental.Models
{
   public class RentalListItem
    {
       
            public int RentalId { get; set; }
            public int? UserId { get; set; }
           
             public double Price { get; set; }
             public DateTime RentalDate { get; set; }

            public DateTime ReturnDate { get; set; }

        public int? ItemId { get; set; }
       

    }
 }

