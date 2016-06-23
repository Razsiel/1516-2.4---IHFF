using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("RestaurantReservation")]
    public class RestaurantReservation
    {
        public RestaurantReservation() { }

        public RestaurantReservation(int EventId, string name, int amount, int tijd, int datum)
        {
            this.ReservationId = EventId;
            this.Amount = amount;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        
        public ICollection<WishlistItem> WishlistItems { get; set; }
        public ICollection<FoodFilm> FoodFilms { get; set; }
    }
}