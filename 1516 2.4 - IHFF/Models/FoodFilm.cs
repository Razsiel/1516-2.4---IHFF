using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("FoodFilm")]
    public class FoodFilm
    {
        public FoodFilm() { }
        public FoodFilm(Event e, RestaurantReservation reservation)
        {
            this.Event = e;
            this.EventId = e.EventId;
            this.Reservation = reservation;
            this.ReservationId = reservation.ReservationId;
            this.Date = e.Date;
        }

        [Key]
        public int FoodFilmId { get; set; }
        public int ReservationId { get; set; }
        public virtual RestaurantReservation Reservation { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        public DateTime Date { get; set; }

        public ICollection<WishlistItem> WishlistItems { get; set; }
    }
}