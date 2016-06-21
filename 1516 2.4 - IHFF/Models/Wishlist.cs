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
            UID = r.Next(0, 9999);
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
        public int UID { get; set; }

        [Required]
        [RegularExpression(@"^[A-z0-9]+@(?:[A-z0-9]+\.)+[A-z]+$", ErrorMessage = "Vul aub een valide email in. voorbeeld: voorbeeld@email.nl")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Namen moeten minimaal 2 karakters bevatten", MinimumLength = 2)]
        public string Name { get; set; }

        public virtual ICollection<WishlistItem> WishlistItems { get; set; }

        [NotMapped]
        public Dictionary<DayOfWeek, int> Discounts
        {
            get
            {
                Dictionary<DayOfWeek, int> discounts = new Dictionary<DayOfWeek, int>();

                // Seperate wishlistitems into lists grouped by day of week
                IEnumerable<List<WishlistItem>> sorted = this.WishlistItems
                    .Where(x => x.Selected == true && !x.PayedFor)
                    .GroupBy(x => x.Date.DayOfWeek)
                    .Select(g => g.ToList());

                foreach (var item in sorted)
                {
                    if (item.Count() > 1)
                    {
                        // Add a discount
                        discounts.Add(item.First().Date.DayOfWeek, 5);
                    }
                }

                return discounts;
            }
        }

        public decimal GetTotalPrice(bool applyDiscounts = false)
        {
            decimal totalPrice = 0;
            foreach (WishlistItem item in this.WishlistItems)
            {
                totalPrice += (item.Selected && !item.PayedFor) ? item.Amount * item.GetPrice() : 0;
            }
            if (applyDiscounts)
            {
                foreach (KeyValuePair<DayOfWeek, int> discount in Discounts)
                {
                    totalPrice *= (1 - (discount.Value / 100m));
                }
            }
            return totalPrice;
        }

        public string GetUIDString()
        {
            return string.Format("IHFF{0}", UID.ToString("00000"));
        }
    }
}