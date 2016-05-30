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
        public ActionResult Index(int Datum, int Tijd, int AantalPersonen)
        {
            Wishlist wishlist = wishlistRepository.GetOrCreateWishlist(Wishlist.Instance.UID);
            // Event e = restaurantsRepository.GetAllRestaurants().First(x => x.EventId == EventId) as Event;

            WishlistItem item = new WishlistItem();
            //item.Event = e;
            item.Wishlist = wishlist;
            item.Amount = AantalPersonen;
            //item.EventId = e.EventId;
            item.PayedFor = false;

            wishlist.WishlistItems.Add(item);

            Wishlist.Instance = wishlist;
            return RedirectToAction("Index", "Wishlist");
        }

        public ActionResult RestaurantInfo(int Id)
        {
            return View(restaurantsRepository.GetRestaurant(Id));
        }
    }
}