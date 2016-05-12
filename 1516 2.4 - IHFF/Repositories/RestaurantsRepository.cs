﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;
using IHFF.Interfaces;

namespace IHFF.Repositories
{
    public class RestaurantsRepository : IRestaurantRepository
    {
        private IHFFContext context = IHFFContext.Instance;

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return context.Restaurants;
        }
    }
}