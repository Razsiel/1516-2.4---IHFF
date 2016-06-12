using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHFF.Models;

namespace IHFF.Interfaces
{
    public interface IRestaurantRepository 
    {
        // beschrijft het gedrag van andere klassen wat er aan moet voldoen 
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant GetRestaurant(int id);
        RestaurantReservation CreateReservation(Restaurant r, int amount, TimeSpan tijd, int datum);
    }
}