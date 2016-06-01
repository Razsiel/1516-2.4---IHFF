using System;
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

        public Restaurant GetRestaurant(int id)
        {
            return context.Restaurants.SingleOrDefault(a => a.EventId == id);
        }

        public void CreateReservation(Restaurant r, int amount, int tijd, int datum)
        {
            RestaurantReservation reservering = new RestaurantReservation();
            reservering.Amount = amount;
            reservering.Tijd = tijd ;
            reservering.Datum = datum;
            reservering.EventId = r.EventId;
            context.RestaurantReservations.Add(reservering);
            context.SaveChanges();
        }
    }
}