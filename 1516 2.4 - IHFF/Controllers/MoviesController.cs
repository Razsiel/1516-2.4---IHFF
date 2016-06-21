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
            return PartialView("_MovieInfo", moviesRepository.GetMovie(Id));
        }

        public ActionResult GetMovies(int day)
        {
            if(day < 0)
            {
                return PartialView("_MovieView", moviesRepository.GetAllUniqueMovies());
            }
            return PartialView("_MovieView", moviesRepository.GetMovies(day));
        }
    }
}