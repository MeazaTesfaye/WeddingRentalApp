using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRental.Models
{
   public class RentalListItem
    {
       
            public int RentalId { get; set; }
            
            public int? UserId { get; set; }

             
            public int? ItemId { get; set; }
             
                
             public DateTime RentalDate { get; set; }

            [Required]
            public DateTime ReturnDate { get; set; }

        }
    }

