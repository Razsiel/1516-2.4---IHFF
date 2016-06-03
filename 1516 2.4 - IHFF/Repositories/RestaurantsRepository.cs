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

        public RestaurantReservation CreateReservation(Restaurant r, int amount, TimeSpan time, int date)
        {
            //Create a new reservation locally
            RestaurantReservation reservation = new RestaurantReservation();
            DateTime d = new DateTime(2016, 6, date, time.Hours, time.Minutes, 0);

            reservation.Amount = amount;
            reservation.Date = d;
            reservation.EventId = r.EventId;
            reservation.Restaurant = r;

            //Get reserving
            RestaurantReservation dbRes = context.RestaurantReservations.Where(x => x.EventId == reservation.EventId && x.Date == reservation.Date && x.Amount == reservation.Amount).First();

            //If it doesn't exist, add it to the database
            if (dbRes == null)
            {
                context.RestaurantReservations.Add(reservation);
                context.SaveChanges();
                dbRes = reservation;
            }

            return dbRes;
        }
    }
}