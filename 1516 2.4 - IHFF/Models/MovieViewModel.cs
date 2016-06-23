using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class MovieViewModel
    {
        private Movie movie;

        public MovieViewModel() { }

        public MovieViewModel(IEnumerable<Restaurant> FoodFilmRestaurants, Movie movie)
        {
            this.movie = movie;
            this.FoodFilmRestaurants = FoodFilmRestaurants;
            this.Actors = movie.Actors;
            this.Airings = movie.Airings;
            this.Description = movie.Description;
            this.Description_NL = movie.Description_NL;
            this.Director = movie.Director;
            this.Duration = movie.Duration;
            this.ExtraInfo = movie.ExtraInfo;
            this.Image = movie.Image;
            this.IMDBRating = movie.IMDBRating;
            this.IMDBUrl = movie.IMDBUrl;
            this.MovieId = movie.MovieId;
            this.Price = movie.Price;
            this.Title = movie.Title;
            this.YearOfRelease = movie.YearOfRelease;
            this.YoutubeLink = movie.YoutubeLink;
        }

        public IEnumerable<Restaurant> FoodFilmRestaurants { get; set; }

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