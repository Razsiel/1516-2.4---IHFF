using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Repositories;
using IHFF.Interfaces;
using IHFF.Models;
using IHFF.Helpers;

namespace IHFF.Controllers
{
    public class HomeController : Controller
    {
        IMovieRepository moviesRepository = new MoviesRepository();
        ISpecialsRepository specialsRepository = new SpecialsRepository();
        IRestaurantRepository restaurantRepository = new RestaurantsRepository();

        private const int MAXELEMENTS = 4;

        public ActionResult Index()
        {
            IEnumerable<Movie> movies = CollectionUtils.GetRandomElements<Movie>(moviesRepository.GetAllUniqueMovies(), MAXELEMENTS);
            IEnumerable<Special> specials = CollectionUtils.GetRandomElements<Special>(specialsRepository.GetAllSpecials(), MAXELEMENTS);
            IEnumerable<Restaurant> restaurants = CollectionUtils.GetRandomElements<Restaurant>(restaurantRepository.GetAllRestaurants(), MAXELEMENTS);

            HomeViewModel hvm = new HomeViewModel(movies, specials, restaurants);
            return View(hvm);
        }
    }
}