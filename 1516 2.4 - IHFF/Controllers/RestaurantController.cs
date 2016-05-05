using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Repositories;
using IHFF.Interfaces;

namespace IHFF.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dijkers()
        {
            return View();
        }
    }
}