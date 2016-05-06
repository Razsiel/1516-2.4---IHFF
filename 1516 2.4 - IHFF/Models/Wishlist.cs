﻿using System;
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
        
        public static Wishlist Instance { get; set; }

        public Wishlist()
        {
            Random rnd = new Random();
            UID = "IHFF1234"; // string.Format("IHFF{0}", rnd.Next(0, 9999).ToString("D4"));
            EmailAddress = "";
            Name = "";
            WishlistItems = new List<WishlistItem>();
        }
    }
}