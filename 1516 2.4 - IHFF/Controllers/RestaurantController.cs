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

        public ActionResult Index() // het resultaat van een actie(methode), laat alle restauranten zien in de view
        {
           return View(restaurantsRepository.GetAllRestaurants());
        }

        [HttpPost] // doormiddel van een httpost wordt de methode/actie alleen uitgevoerd/verwerkt/handeld met HTTP post requesten 
        public ActionResult Index(int Date, TimeSpan Time, int Amount, int RestaurantId)
        {
            Wishlist wishlist = Wishlist.Instance;

            Restaurant restaurant = restaurantsRepository.GetRestaurant(RestaurantId);
            RestaurantReservation r = restaurantsRepository.CreateReservation(restaurant, Amount, Time, Date);

            WishlistItem item = new WishlistItem(r, wishlist);

            wishlist.AddItemToWishlist(item);

            return RedirectToAction(nameof(WishlistController.Index), "Wishlist");
        }

        public ActionResult RestaurantInfo(int RestaurantId) // Het resultaat/methode/actie van het drukken op een specefiek restaurant waarbij er wordt gekeken naar de res.id en dit wordt gematched, waardoor de juiste info naar voren komt. 
        {
            return View(restaurantsRepository.GetRestaurant(RestaurantId));
        }
    }
}