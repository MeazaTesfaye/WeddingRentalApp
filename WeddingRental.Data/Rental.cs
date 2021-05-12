using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRental.Data
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public double Price { get; set; }
       
        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        
        [ForeignKey(nameof(Item))]
        public int? ItemId { get; set; }
        public virtual Item Item { get; set; }
        public DateTime RentalDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
    }
}
