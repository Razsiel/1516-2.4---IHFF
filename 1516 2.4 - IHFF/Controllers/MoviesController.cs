using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;
using IHFF.Repositories;
using IHFF.Interfaces;

namespace IHFF.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieRepository moviesRepository = new MoviesRepository();
        private IWishlistRepository wishlistRepository = new WishlistRepository();
        private IRestaurantRepository restaurantRepository = new RestaurantsRepository();
        private IFoodFilmRepository foodFilmRepository = new FilmFoodRepository();

        public ActionResult Index()
        {
            return View(moviesRepository.GetAllUniqueMovies());
        }

        [HttpPost]
        public ActionResult Index(int EventId, int ticketAmount)
        {
            Wishlist wishlist = Wishlist.Instance;
            Event e = moviesRepository.GetMovieEvent(EventId);
            if (e == null)
            {
                return RedirectToAction(nameof(Index));
            }
            WishlistItem item = new WishlistItem(e, ticketAmount, wishlist);

            wishlist.AddItemToWishlist(item);
            return RedirectToAction(nameof(WishlistController.Index), "Wishlist");
        }

        public ActionResult MovieInfo(int Id)
        {
            MovieViewModel model = new MovieViewModel(restaurantRepository.GetFoodFilmRestaurants(), moviesRepository.GetMovie(Id));
            return PartialView("_MovieInfo", model);
            //return PartialView("_MovieInfo", moviesRepository.GetMovie(Id));
        }

        public ActionResult GetMovies(int day)
        {
            if(day < 0)
            {
                return PartialView("_MovieView", moviesRepository.GetAllUniqueMovies());
            }
            return PartialView("_MovieView", moviesRepository.GetMovies(day));
        }

        public ActionResult FoodAndFilm(int restaurantId, int filmId)
        {
            FoodFilmViewModel model = new FoodFilmViewModel(restaurantRepository.GetRestaurant(restaurantId), moviesRepository.GetMovie(filmId));
            return PartialView("_FoodAndFilm", model);
        }

        [HttpPost]
        public ActionResult FoodAndFilm(int EventId, int RestaurantId, TimeSpan RestaurantTime, int ticketAmount)
        {
            Wishlist wishlist = Wishlist.Instance;
            Event e = moviesRepository.GetMovieEvent(EventId);

            Restaurant restaurant = restaurantRepository.GetRestaurant(RestaurantId);
            RestaurantReservation r = restaurantRepository.CreateReservation(restaurant, ticketAmount, RestaurantTime, (int)e.Date.DayOfWeek);

            FoodFilm foodFilm = new FoodFilm(e, r);

            foodFilmRepository.AddFoodFilm(foodFilm);

            WishlistItem item = new WishlistItem(foodFilm, wishlist);

            wishlist.AddItemToWishlist(item);
            return RedirectToAction(nameof(WishlistController.Index), "Wishlist");
        }
    }
}