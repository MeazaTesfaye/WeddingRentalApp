using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRental.Models.Item
{
   public class ItemEdit
    {

        public int ItemId { get; set; }

        // [ForeignKey(nameof(User))]
        // public int UserId { get; set; }

        [Required]
        public double Price { get; set; }


        [Required]
        public string PickupAddress { get; set; }

        [Required]
        public string DropoffAddress { get; set; }
        public enum Type { get, set, }
        public string Brand { get; set; }
    }
}

