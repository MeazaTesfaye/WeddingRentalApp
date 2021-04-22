using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRental.Models.Item
{
   public class CreateItem
    {
       

        // [ForeignKey(nameof(User))]
        // public int UserId { get; set; }

        [Required]
  
        public double Price { get; set; }

        public string PickupAddress { get; set; }

        public string DropoffAddress { get; set; }
    }
}

