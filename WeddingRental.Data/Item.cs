using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRental.Data
{
  
    public class Item

    {
        [Key]
        public int ItemId { get; set; }

        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        public double Price { get; set; }
        
        [ForeignKey(nameof(Rating))]
        public int? RaterId { get; set; }
        public virtual Rating Rating { get; set; }
        public double Star { get; set; }

        public string Brand { get; set; }

        [Required]
        public string PickupAddress { get; set; }

        [Required]
        public string DropoffAddress { get; set; }

    }
}
