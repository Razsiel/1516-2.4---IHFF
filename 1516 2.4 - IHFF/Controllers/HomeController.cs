using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Repositories;
using IHFF.Interfaces;
using IHFF.Models;

namespace IHFF.Controllers
{
    public class HomeController : Controller
    {
        IMovieRepository moviesRepository = new MoviesRepository();
        ISpecialsRepository specialsRepository = new SpecialsRepository();
        IRestaurantRepository restaurantRepository = new RestaurantsRepository();

        public ActionResult Index()
        {
            Random rand = new Random();

            IEnumerable<Movie> m = moviesRepository.GetAllUniqueMovies();
            List<Movie> movies = new List<Movie>();
            while (movies.Count() < 4)
            {
                Movie randomMovie = m.ElementAt(rand.Next(0, m.Count() - 1));
                while (movies.Exists(x => x.MovieId == randomMovie.MovieId))
                {
                    randomMovie = m.ElementAt(rand.Next(0, m.Count() - 1));
                }
                movies.Add(randomMovie);
            }

            IEnumerable<Special> s = specialsRepository.GetAllSpecials();
            List<Special> specials = new List<Special>();
            while (specials.Count() < 4)
            {
                specials.Add(s.ElementAt(rand.Next(0, s.Count())));
            }

            IEnumerable<Restaurant> r = restaurantRepository.GetAllRestaurants();
            List<Restaurant> restaurants = new List<Restaurant>();
            while (restaurants.Count() < 4)
            {
                Restaurant randomRestaurant = r.ElementAt(rand.Next(0, r.Count()));
                while (restaurants.Exists(x => x.RestaurantId == randomRestaurant.RestaurantId))
                {
                    randomRestaurant = r.ElementAt(rand.Next(0, r.Count()));
                }
                restaurants.Add(randomRestaurant);
            }

            HomeViewModel hvm = new HomeViewModel(movies, specials, restaurants);
            return View(hvm);
        }
    }
}