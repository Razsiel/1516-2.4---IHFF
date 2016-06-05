using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class HomeViewModel
    {
        public HomeViewModel(
            IEnumerable<Movie> movies, 
            IEnumerable<Special> specials, 
            IEnumerable<Restaurant> restaurants)
        {
            Movies = movies;
            Specials = specials;
            Restaurants = restaurants;
        }

        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Special> Specials { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}