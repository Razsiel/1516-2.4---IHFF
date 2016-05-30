using IHFF.Interfaces;
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
        private IMovieRepository specialsRepository = new MoviesRepository();
        private IWishlistRepository wishlistRepository = new WishlistRepository();

        // GET: Specials
        public ActionResult Index()
        {
            return View();
        }
    }
}