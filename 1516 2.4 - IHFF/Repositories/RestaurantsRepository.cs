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
        private IHFFContext context = IHFFContext.Instance; //singleton, maar 1 connectie met de databas wordt gecommuniceert 

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return context.Restaurants;
        }

        public Restaurant GetRestaurant(int id)
        {
            return context.Restaurants.SingleOrDefault(a => a.EventId == id); // "== lambda" er wordt gekeken naar alle restaurants in de context (database) en wordt alsvolg gechecked naar (de id) 
        }

        public RestaurantReservation CreateReservation(Restaurant r, int amount, TimeSpan time, int date)
        {
            //Create a new reservation locally, bij dubbele reservaties, want we kunnen niet 2x exact dezelfde data in de database ontstaan 
            RestaurantReservation reservation = new RestaurantReservation();
            DateTime d = new DateTime(2016, 6, date, time.Hours, time.Minutes, 0);

            reservation.Amount = amount;
            reservation.Date = d;
            reservation.EventId = r.EventId;
            reservation.Restaurant = r;

            //Get reserving
            IQueryable<RestaurantReservation> dbRes = context.RestaurantReservations.Where(x => x.EventId == reservation.EventId && x.Date == reservation.Date && x.Amount == reservation.Amount);

            //If it doesn't exist, add it to the database
            if (dbRes.Count() == 0)
            {
                context.RestaurantReservations.Add(reservation);
                context.SaveChanges();
                return reservation;
            }

            return dbRes.FirstOrDefault();
        }
    }
}