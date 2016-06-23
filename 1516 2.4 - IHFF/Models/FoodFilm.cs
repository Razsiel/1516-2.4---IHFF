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
        [Key]
        public int FoodFilmId { get; set; }
        public int ReservationId { get; set; }
        public virtual RestaurantReservation Reservation { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public ICollection<WishlistItem> WishlistItems { get; set; }
    }
}