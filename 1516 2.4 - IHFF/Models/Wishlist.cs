using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("Wishlists")]
    public class Wishlist
    {
        [Key]
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string UID { get; set; }

        public ICollection<WishlistItem> WishlistItems { get; set; }
    }
}