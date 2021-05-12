using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRental.Models
{
    public class RentalCreate
    {
        [Key]
        public int RentalId { get; set; }
        
        public int ItemId { get; set; }
        
       public double Price { get; set; }
       
        public int UserId { get; set; }

        [Required]
        public DateTime RentalDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }
    }
}
