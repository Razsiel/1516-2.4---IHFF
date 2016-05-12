using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;

namespace IHFF.Interfaces
{
    public interface IRestaurantRepository 
    {
        IEnumerable<Restaurant> GetAllRestaurants();
    }
}