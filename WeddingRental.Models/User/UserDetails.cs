using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRental.Data;

namespace WeddingRental.Models.User
{
   public class UserDetails
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Address { get; set; }
        public Guid OwnerId { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();// can rent multiple items/Rentals
    }
}
