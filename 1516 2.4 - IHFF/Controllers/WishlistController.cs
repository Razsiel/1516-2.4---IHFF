using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;
using IHFF.Interfaces;
using IHFF.Repositories;

namespace IHFF.Controllers
{
    public class WishlistController : Controller
    {
        IWishlistRepository wishlistRepository = new WishlistRepository();
        IMovieRepository movieRepository = new MoviesRepository();

        public ActionResult Index()
        {
            return View(Wishlist.Instance);
        }

        public ActionResult SaveWishlist(Wishlist wishlist)
        {
            Wishlist.Instance = wishlist;
            //wishlistRepository.SaveWishlist(Wishlist.Instance);
            return PartialView("_PopupSave", Wishlist.Instance);
        }

        public ActionResult Checkout(Wishlist wishlist)
        {
            Wishlist.Instance = wishlist;
            wishlistRepository.Checkout(Wishlist.Instance);
            return RedirectToAction("Index");
        }
        
        public ActionResult RemoveItem(WishlistItem item)
        {
            Wishlist.Instance.WishlistItems.Remove(item);
            return RedirectToAction("Index");
        }
    }
}