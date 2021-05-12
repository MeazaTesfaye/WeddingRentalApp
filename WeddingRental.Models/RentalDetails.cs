using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRental.Models.Item;
using WeddingRental.Models.User;

namespace WeddingRental.Models
{
    public class RentalDetails
    {
        [Key]
        public int RentalId { get; set; }
        public int? ItemId { get; set; }
        public double Star { get; set; }
        public virtual ItemListItem Items { get; set; }
        public int? UserId { get; set; }
        public virtual UserListItem Users { get; set; }
        public DateTime  RentalDate { get; set; }
        public double Price { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
