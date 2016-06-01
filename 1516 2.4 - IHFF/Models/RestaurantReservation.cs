using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("Restaurants")]
    public class RestaurantReservation
    {
        public RestaurantReservation() { }
        
        public RestaurantReservation( int EventId, string name, int amount, int tijd, int datum)
        {
            this.EventId = EventId;
            this.Name = name;
            this.Amount = amount;
            this.Tijd = tijd;
            this.Datum = datum;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set;}
        public int Tijd { get; set; }
        public int Datum { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}