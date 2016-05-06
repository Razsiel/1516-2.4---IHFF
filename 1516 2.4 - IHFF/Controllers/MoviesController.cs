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
        public ActionResult Index(int AiringId, int ticketAmount)
        {
            /*Pseudo-code steps

            - Get airing
            - Get or create a wishlist
            - Create wishlist item based on airing (activity)
            - Add wishlistitem to wishlist

            */
            Airing airing = moviesRepository.GetAiring(AiringId);
            airing.Name = airing.Movie.Title;
            airing.Image = airing.Movie.Image;
            Wishlist wishlist = wishlistRepository.GetOrCreateWishlist(Wishlist.Instance.UID);

            WishlistItem item = new WishlistItem(airing, wishlist, ticketAmount);
            wishlist.WishlistItems.Add(item);
            
            Wishlist.Instance = wishlist;
            return RedirectToAction("Index", "Wishlist");
        }
    }
}