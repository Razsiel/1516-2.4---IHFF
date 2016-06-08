using IHFF.Interfaces;
using IHFF.Models;
using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class SpecialsController : Controller
    {
        private ISpecialsRepository specialsRepository = new SpecialsRepository();
        private IWishlistRepository wishlistRepository = new WishlistRepository();

        // GET: Specials
        public ActionResult Index()
        {
            return View(specialsRepository.GetAllSpecials());
        }

        [HttpPost]
        public ActionResult Index(int EventId, int ticketAmount)
        {
            Wishlist wishlist = wishlistRepository.GetWishlist(Wishlist.Instance.UID);
            Event e = specialsRepository.GetSpecialEvent(EventId);

            WishlistItem item = new WishlistItem(e, ticketAmount, wishlist);

            wishlist.WishlistItems.Add(item);

            Wishlist.Instance = wishlist;
            return RedirectToAction("Index", "Wishlist");
        }

        public ActionResult GetSpecials(int Id)
        {
            return PartialView("_SpecialView", specialsRepository.GetSpecials(Id));
        }
    }
}