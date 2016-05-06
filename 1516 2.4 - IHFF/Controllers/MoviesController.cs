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

        public ActionResult Index()
        {
            return View(moviesRepository.GetAllMovies());
        }

        [HttpPost]
        public ActionResult Index(Airing airing, int ticketAmount)
        {

            //Get airing and create wishlist item based on it
            return RedirectToAction("AddAiringToWishlist", "Wishlist");
        }
    }
}