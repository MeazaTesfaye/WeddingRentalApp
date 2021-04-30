using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRental.Data
{
    public class Rating
    {
        [Key]
        public int RaterId { get; set; }
        public int? ItemId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public double Star { get; set; }
        [Required]
        public string Text { get; set; }
        public string UserName { get; set; }
    }
}
