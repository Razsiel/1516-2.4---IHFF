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
    public class RestaurantController : Controller
    {
        private IRestaurantRepository restaurantsRepository = new RestaurantsRepository();
        
        public ActionResult Index()
        {
           return View(restaurantsRepository.GetAllRestaurants());
        }

        public ActionResult Dijkers()
        {
            return View();
        }
    }
}