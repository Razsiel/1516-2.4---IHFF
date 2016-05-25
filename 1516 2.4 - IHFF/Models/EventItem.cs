using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("EventItem")]
    public abstract class EventItem
    {
        [Key]
        public int EventId { get; set; }
        public int Amount { get; set; }
        public bool PayedFor { get; set; }

        public string WishlistUID { get; set; }
        public virtual Wishlist Wishlist { get; set; }
    }
}