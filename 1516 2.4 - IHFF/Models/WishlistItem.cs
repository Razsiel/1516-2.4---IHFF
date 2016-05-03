using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("WishlistItems")]
    public class WishlistItem
    {
        public virtual Wishlist Wishlist { get; set; }
        public int Item_Id { get; set; }
        public int Amount { get; set; }
        public bool Reserved { get; set; }
    }
}