using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("EventItem")]
    public class WishlistItem
    {
        public int WishlistItemId { get; set; }
        public int Amount { get; set; }
        public bool PayedFor { get; set; }
        
        public string WishlistUID { get; set; }
        public virtual Wishlist Wishlist { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}