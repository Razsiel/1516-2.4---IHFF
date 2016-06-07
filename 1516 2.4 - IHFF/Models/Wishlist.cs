using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("Wishlist")]
    public class Wishlist
    {
        private Wishlist()
        {
            Random r = new Random();
            WishlistItems = new List<WishlistItem>();
            UID = string.Format("IHFF{0}", r.Next(0, 9999).ToString("0000"));
        }

        private static Wishlist _instance;
        public static Wishlist Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Wishlist();
                }
                return _instance;
            }
            set { _instance = value; }
        }

        [Key]
        public string UID { get; set; }

        [Required]
        [RegularExpression(@"^[A-z0-9]+@(?:[A-z0-9]+\.)+[A-z]+$", ErrorMessage = "Vul aub een valide email in. voorbeeld: voorbeeld@email.nl")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Namen moeten minimaal 2 karakters bevatten", MinimumLength = 2)]
        public string Name { get; set; }

        public virtual ICollection<WishlistItem> WishlistItems { get; set; }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (WishlistItem item in this.WishlistItems)
            {
                switch (item.GetItemType())
                {
                    default:
                    case ItemType.Event:
                        totalPrice += item.Selected && !item.PayedFor ? item.Amount * item.GetPrice() : 0;
                        break;
                    case ItemType.Reservation:
                        totalPrice += item.Selected && !item.PayedFor ? item.GetPrice() : 0;
                        break;
                }
            }
            return totalPrice;
        }
    }
}