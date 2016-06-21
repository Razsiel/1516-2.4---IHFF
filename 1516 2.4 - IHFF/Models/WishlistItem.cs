using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("WishlistItem")]
    public class WishlistItem
    {
        private const int RESERVATIONPRICE = 10;

        public WishlistItem() { }

        public WishlistItem(Event e, int amount, Wishlist wishlist)
        {
            Amount = amount;
            PayedFor = false;
            WishlistUID = wishlist.UID;
            Wishlist = wishlist;
            ItemId = e.EventId;
            Event = e;
            Discriminator = e.Discriminator;
        }

        public WishlistItem(RestaurantReservation r, Wishlist wishlist)
        {
            Amount = r.Amount;
            PayedFor = false;
            WishlistUID = wishlist.UID;
            Wishlist = wishlist;
            ItemId = r.ReservationId;
            Reservation = r;
            Discriminator = "Reservation";
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishlistItemId { get; set; }
        public int WishlistUID { get; set; }
        public virtual Wishlist Wishlist { get; set; }
        
        public int ItemId { get; set; }
        public virtual Event Event { get; set; }
        public virtual RestaurantReservation Reservation { get; set; }

        public int Amount { get; set; }
        public bool PayedFor { get; set; }

        public string Discriminator { get; set; }

        [NotMapped]
        public bool Selected { get; set; } = true;

        public ItemType GetItemType()
        {
            switch (this.Discriminator)
            {
                case "Movie":
                case "Special":
                default:
                    return ItemType.Event;
                case "Reservation":
                    return ItemType.Reservation;
            }
        }

        public string GetName()
        {
            switch (GetItemType())
            {
                case ItemType.Event:
                    return Event.GetName();
                case ItemType.Reservation:
                    return Reservation.Restaurant.Name;
                default:
                    return "";
            }
        }
        public string GetLocation()
        {
            switch (GetItemType())
            {
                case ItemType.Event:
                    return Event.LocationString;
                case ItemType.Reservation:
                    return Reservation.Restaurant.Address;
                default:
                    return "";
            }
        }
        public string GetImage()
        {
            switch (GetItemType())
            {
                case ItemType.Event:
                    return Event.GetImage();
                case ItemType.Reservation:
                    return Reservation.Restaurant.Image;
                default:
                    return "";
            }
        }
        public decimal GetPrice()
        {
            switch (GetItemType())
            {
                case ItemType.Event:
                    return Event.GetPrice() * Amount;
                case ItemType.Reservation:
                    return RESERVATIONPRICE * Amount;
                default:
                    return 0;
            }
        }

        [NotMapped]
        public DateTime Date
        {
            get
            {
                switch (GetItemType())
                {
                    case ItemType.Event:
                        return Event.Date;
                    case ItemType.Reservation:
                        return Reservation.Date;
                    default:
                        return DateTime.MinValue;
                }
            }
        }

        //public FoodFilm FoodFilm { get; internal set; }
    }

    public enum ItemType
    {
        Event,
        Reservation,
        Movie,
        Special
    }
}