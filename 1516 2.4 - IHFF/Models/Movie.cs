using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("Movie")]
    public class Movie
    {
        public Movie() { }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public Int16 YearOfRelease { get; set; }
        public byte IMDBRating { get; set; }
        public string Actors { get; set; }
        public string Description { get; set; }
        public string IMDBUrl { get; set; }
        public string Image { get; set; }
        public string ExtraInfo { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description_NL { get; set; }
        public decimal Price { get; set; }
        public string YoutubeLink { get; set; }

        public virtual ICollection<Event> Airings { get; set; }

        public string GetName()
        {
            return this.Title;
        }

        public string GetImage()
        {
            return this.Image;
        }

        public decimal GetPrice()
        {
            return this.Price;
        }
    }
}