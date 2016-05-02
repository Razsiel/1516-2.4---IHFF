using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("Movies")]
    public class Movie
    {
        public Movie() { }

        public Movie(int id, string title, string director, Int16 yearOfRelease, byte rating, string actors, string description, string url, string image)
        {
            this.Id = id;
            this.Title = title;
            this.Director = director;
            this.YearOfRelease = yearOfRelease;
            this.IMDBRating = rating;
            this.Actors = actors;
            this.Description = description;
            this.IMDBUrl = url;
            this.Image = image;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public Int16 YearOfRelease { get; set; }
        public byte IMDBRating { get; set; }
        public string Actors { get; set; }
        public string Description { get; set; }
        public string IMDBUrl { get; set; }
        public string Image { get; set; }
    }
}