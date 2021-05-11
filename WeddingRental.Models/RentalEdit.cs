using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRental.Models
{
    public class RentalEdit
    {
        public int RentalId { get; set; }
        public int? ItemId { get; set; }
        public double Price { get; set; }
         public int? UserId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
