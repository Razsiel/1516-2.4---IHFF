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

        public IEnumerable<Restaurant> GetAllRestaurants() //methode "GetALLRestaurant, haalt vanuit de database alle restaurants op, !waar worden ze opgeslagen dan ?"
        {
            return context.Restaurants;
        }

        public Restaurant GetRestaurant(int id) // methode "GetRestaurant" die naar het specefiek restaurant zoekt/match in DB doormiddel van ID !waar word het opgeslagen dan ?
        {
            return context.Restaurants.SingleOrDefault(a => a.RestaurantId == id);
        }

        public RestaurantReservation CreateReservation(Restaurant r, int amount, TimeSpan time, int date) //Restaurant reservatie methode/actie
        {
            //Create a new reservation locally
            RestaurantReservation reservation = new RestaurantReservation();
            DateTime d = new DateTime(2016, 6, date, time.Hours, time.Minutes, 0);

            reservation.Amount = amount;
            reservation.Date = d;
            reservation.RestaurantId = r.RestaurantId;
            reservation.Restaurant = r;

            //Get reserving van database (controle of hij wel erin is of niet)
            IQueryable<RestaurantReservation> dbRes = context.RestaurantReservations.Where(x => x.ReservationId == reservation.ReservationId);

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