using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRental.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        
        //public int? ItemId { get; set; }
        //public virtual Item Item { get; set; }
        public string Address { get; set; }
        public Guid OwnerId { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();// can rent multiple items/Rentals
    }
}
