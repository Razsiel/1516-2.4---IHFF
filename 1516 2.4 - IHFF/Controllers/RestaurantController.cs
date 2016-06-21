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
    public class RestaurantController : Controller
    {
        private IRestaurantRepository restaurantsRepository = new RestaurantsRepository();
        private IWishlistRepository wishlistRepository = new WishlistRepository();

        public ActionResult Index()
        {
           return View(restaurantsRepository.GetAllRestaurants());
        }

        [HttpPost]
        public ActionResult Index(int Date, TimeSpan Time, int Amount, int RestaurantId)
        {
            Wishlist wishlist = Wishlist.Instance;

            Restaurant restaurant = restaurantsRepository.GetRestaurant(RestaurantId);
            RestaurantReservation r = restaurantsRepository.CreateReservation(restaurant, Amount, Time, Date);

            WishlistItem item = new WishlistItem(r, wishlist);

            wishlist.WishlistItems.Add(item);

            Wishlist.Instance = wishlist;
            return RedirectToAction(nameof(WishlistController.Index), "Wishlist");
        }

        public ActionResult RestaurantInfo(int RestaurantId)
        {
            return View(restaurantsRepository.GetRestaurant(RestaurantId));
        }
    }
}