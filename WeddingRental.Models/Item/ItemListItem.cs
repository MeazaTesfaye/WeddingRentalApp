using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRental.Models.Item
{
    public class ItemListItem
    {
        public int ItemId { get; set; }

        public double  Star { get; set; }
        public int? UserId { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string PickupAddress { get; set; }

        [Required]
        public string DropoffAddress { get; set;}
    }
}
