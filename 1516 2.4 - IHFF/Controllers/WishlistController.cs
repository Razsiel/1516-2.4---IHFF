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
        IMovieRepository moviesRepository = new MoviesRepository();

        public ActionResult Index()
        {
            return View(Wishlist.Instance);
        }

        [HttpPost]
        public ActionResult GetWishlist(string UID)
        {
            Wishlist.Instance = wishlistRepository.GetWishlist(UID);
            return RedirectToAction("Index");
        }

        
        public ActionResult SaveWishlist(string Name, string Email)
        {
            if (ModelState.IsValid)
            {
                Wishlist.Instance.Name = Name;
                Wishlist.Instance.Email = Email;
                //wishlistRepository.SaveWishlist(Wishlist.Instance);
                return PartialView("_PopupSave", Wishlist.Instance);
            }
            return View(Wishlist.Instance);
        }

        public ActionResult Checkout(Wishlist wishlist)
        {
            return RedirectToAction("Index");
        }
        
        public ActionResult RemoveItem(WishlistItem item)
        {
            return RedirectToAction("Index");
        }
    }
}