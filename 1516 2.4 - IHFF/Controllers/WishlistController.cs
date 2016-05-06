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
        IWishlistItemRepository wishlistItemRepository = new WishlishItemrepository();

        public ActionResult Index()
        {
            return View(Wishlist.Instance);
        }

        public ActionResult AddAiringToWishlist(Airing airing)
        {
            Wishlist wishlist = wishlistRepository.GetOrCreateWishlist(null);

            return RedirectToAction("Index");
        }
    }
}