using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class FoodFilmViewModel
    {
        public FoodFilmViewModel() { }

        public FoodFilmViewModel(Restaurant res, Movie movie)
        {
            this.MovieId = movie.MovieId;
            this.MovieImage = movie.Image;
            this.MovieTitle = movie.Title;
            this.Airings = movie.Airings;
            this.RestaurantId = res.RestaurantId;
            this.RestaurantImage = res.ResImage3;
            this.RestaurantName = res.Name;
        }

        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieImage { get; set; }
        public virtual ICollection<Event> Airings { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantImage{ get; set; }
    }
}