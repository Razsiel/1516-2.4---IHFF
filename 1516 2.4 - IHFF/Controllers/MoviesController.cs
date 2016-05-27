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

        public ActionResult Index()
        {
            return View(moviesRepository.GetAllMovies());
        }

        [HttpPost]
        public ActionResult Index(int EventId, int ticketAmount)
        {
            Wishlist wishlist = wishlistRepository.GetOrCreateWishlist(Wishlist.Instance.UID);
            Event e = moviesRepository.GetAllMovies().First(x => x.EventId == EventId) as Event;

            WishlistItem item = new WishlistItem();
            item.Event = e;
            item.Wishlist = wishlist;
            item.Amount = ticketAmount;
            item.EventId = e.EventId;
            item.PayedFor = false;

            wishlist.WishlistItems.Add(item);
            
            Wishlist.Instance = wishlist;
            return RedirectToAction("Index", "Wishlist");
        }

        public ActionResult MovieInfo(int Id)
        {
            return PartialView("_MovieInfo", moviesRepository.GetMovie(Id));
        }
    }
}