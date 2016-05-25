using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("Movie")]
    public class Movie : Event
    {
        public Movie() { }
        
        public string Title { get; set; }
        public string Director { get; set; }
        public Int16 YearOfRelease { get; set; }
        public byte IMDBRating { get; set; }
        public string Actors { get; set; }
        public string Description { get; set; }
        public string IMDBUrl { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public TimeSpan Duration { get; set; }
        [NotMapped]
        public string Description_NL { get; set; }
        [NotMapped]
        public decimal Price { get; set; }
    }
}