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
            this.EventId = EventId;
            this.Amount = amount;
        }

        [Key, Column(Order = 0)]
        public int EventId { get; set; }

        [Key, Column(Order = 1)]
        public DateTime Date { get; set; }

        [Key, Column(Order = 2)]
        public int Amount { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}