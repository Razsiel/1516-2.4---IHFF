using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("WishlistItems")]
    public class WishlistItem
    {
        [Key, Column(Order = 0)]
        public int Wishlist_Id { get; set; }
        public virtual Wishlist Wishlist { get; set; }
        [Key, Column(Order = 1)]
        public int Item_Id { get; set; }
        [Key, Column(Order = 2)]
        public int ItemType { get; set; }
        public int Amount { get; set; }
        public bool Reserved { get; set; }
    }
}