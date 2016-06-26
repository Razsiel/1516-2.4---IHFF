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
            Discounts = new List<DiscountRule>();
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
        public IDictionary<DayOfWeek, IEnumerable<WishlistItem>> DayItems
        {
            get
            {
                return this.WishlistItems
                .GroupBy(x => x.Date.DayOfWeek)
                .Select(g => g)
                .ToDictionary(x => x.Key, y => y.AsEnumerable<WishlistItem>());
            }
        }

        [NotMapped]
        public IDictionary<DayOfWeek, IEnumerable<WishlistItem>> SelectedDayItems
        {
            get
            {
                return this.WishlistItems
                .Where(x => x.Selected && !x.PayedFor && x.Available)
                .GroupBy(x => x.Date.DayOfWeek)
                .Select(g => g)
                .ToDictionary(x => x.Key, y => y.AsEnumerable<WishlistItem>());
            }
        }

        [NotMapped]
        public IDictionary<DayOfWeek, decimal> DayPrices
        {
            get
            {
                IDictionary<DayOfWeek, IEnumerable<WishlistItem>> dayItems = this.SelectedDayItems;
                IDictionary<DayOfWeek, decimal> dayPrices = new Dictionary<DayOfWeek, decimal>();

                foreach (KeyValuePair<DayOfWeek, IEnumerable<WishlistItem>> day in dayItems)
                {
                    decimal dayPrice = 0;
                    foreach (WishlistItem item in day.Value)
                    {
                        if (item.Amount > 1 && item.Discriminator != ItemType.FoodFilm.ToString())
                        {
                            foreach (DiscountRule discount in Discounts.Where(x => x is MultiplePeopleDiscount))
                            {
                                if (discount.DiscountEvent == item)
                                {
                                    dayPrice += (item.GetPrice() * (1 - discount.Percentage));
                                }
                            }
                        }
                        else if (item.Amount > 1 && item.Discriminator == ItemType.FoodFilm.ToString())
                        {
                            dayPrice += item.GetPrice();
                        }
                        else
                        {
                            dayPrice += item.GetPrice();
                        }
                    }
                    dayPrices.Add(day.Key, dayPrice);
                }

                return dayPrices;
            }
        }

        [NotMapped]
        public IList<DiscountRule> Discounts { get; set; }

        public decimal GetTotalPrice(bool applyDiscounts = false)
        {
            IDictionary<DayOfWeek, decimal> dayPrices = this.DayPrices;

            if (applyDiscounts)
            {
                IDictionary<DayOfWeek, decimal> endDayPrices = new Dictionary<DayOfWeek, decimal>();

                foreach (var item in dayPrices)
                {
                    decimal discountedPrice = item.Value;
                    foreach (DiscountRule discount in Discounts)
                    {
                        if (discount is MultipleActivitiesDayDiscount)
                        {
                            discountedPrice *= (1 - discount.Percentage);
                        }
                    }
                    endDayPrices.Add(item.Key, discountedPrice);
                }

                return endDayPrices.Values.Sum();
            }

            return dayPrices.Values.Sum();
        }

        public void DetermineDiscounts()
        {
            Discounts = new List<DiscountRule>();

            foreach (var day in SelectedDayItems.Values.ToList())
            {
                if (day.Where(x => x.Discriminator != ItemType.FoodFilm.ToString()).Count() > 1)
                {
                    Discounts.Add(new MultipleActivitiesDayDiscount(day.First().Date.DayOfWeek));
                }
            }

            foreach (WishlistItem item in this.WishlistItems)
            {
                if (item.Amount > 1)
                {
                    if (item.Discriminator == ItemType.Movie.ToString() || item.Discriminator == ItemType.Reservation.ToString())
                    {
                        Discounts.Add(new MultiplePeopleDiscount(item));
                    }
                }
            }
        }

        public string GetUIDString()
        {
            return string.Format("IHFF{0}", UID.ToString("00000"));
        }

        public void AddItemToWishlist(WishlistItem item)
        {
            this.WishlistItems.Add(item);
            this.DetermineDiscounts();
        }
    }
}