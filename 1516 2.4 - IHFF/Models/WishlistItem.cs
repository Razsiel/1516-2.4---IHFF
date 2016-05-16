using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("WishlistItems")]
    public class WishlistItem
    {
        public WishlistItem() { }

        public WishlistItem(ActivityType activity, Wishlist wishlist, int tickets)
        {
            Item = activity;
            Wishlist = wishlist;
            Wishlist_Id = wishlist.Id;
            Amount = tickets;
        }

        [Key, Column(Order = 0)]
        public int Wishlist_Id { get; set; }
        public virtual Wishlist Wishlist { get; set; }
        [Key, Column(Order = 1)]
        public int Item_Id { get; set; }
        [Key, Column(Order = 2)]
        public int ItemType { get; set; }
        public int Amount { get; set; }
        public bool Reserved { get; set; }

        public virtual ActivityType Item { get; set; }

        [NotMapped]
        public bool Selected { get; set; }
    }
}