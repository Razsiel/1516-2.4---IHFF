using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Repositories;
using IHFF.Interfaces;

namespace IHFF.Controllers
{
    public class HomeController : Controller
    {
        IMovieRepository moviesRepository = new MoviesRepository();
        ISpecialsRepository specialsRepository = new SpecialsRepository();
        IRestaurantRepository restaurantRepository = new RestaurantsRepository();

        public ActionResult Index()
        {
            return View();
        }
    }
}