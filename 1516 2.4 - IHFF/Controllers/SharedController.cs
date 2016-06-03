using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Repositories;
using IHFF.Interfaces;
using IHFF.Models;

namespace IHFF.Controllers
{
    public class SharedController : Controller
    {
        IWishlistRepository wishlistRepository = new WishlistRepository();

        public ActionResult ShowMiniWishlist()
        {
            return PartialView("_WishlistMini", Wishlist.Instance);
        }
    }
}