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
        IWishlistRepository repository = new WishlistRepository();

        public ActionResult Index()
        {
            return View(Wishlist.Instance);
        }

        public ActionResult AddAiringToWishlist(AiringItem airingItem)
        {
            Wishlist wishlist = repository.GetOrCreateWishlist(null);
            WishlistItem item = new WishlistItem();
            item.Wishlist = wishlist;
            item.Wishlist_Id = wishlist.Id;
            item.Amount = airingItem.amountOfTickets;

            wishlist.WishlistItems.Add(item);

            return RedirectToAction("Index");
        }
    }
}