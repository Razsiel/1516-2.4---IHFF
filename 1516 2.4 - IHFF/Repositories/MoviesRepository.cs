using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;
using IHFF.Interfaces;
using System.Data.Entity;

namespace IHFF.Repositories
{
    public class MoviesRepository : IMovieRepository
    {
        private IHFFContext context = IHFFContext.Instance;
        
        // Get unique movie titles -> new list
        // for each unique movie get all the events associated with it
        public IEnumerable<Movie> GetAllUniqueMovies()
        {
            //Get all right events with discriminator 'Movie'
            return context.Movies;
        }

        public Movie GetMovie(int id)
        {
            return context.Movies.FirstOrDefault(a => a.MovieId == id);
        }

        //Get all movies
        //Filter based on event date
        public IEnumerable<Movie> GetMovies(int dayOfWeek)
        {
            IEnumerable<Movie> allMovies = GetAllUniqueMovies();
            List<Movie> filteredMovies = new List<Movie>();

            //Get a list of all films that have a date corresponding to dayOfWeek
            foreach (Movie m in allMovies)
            {
                if (m.Airings.Where(x => x.Date.DayOfWeek == (DayOfWeek)dayOfWeek && x.Discriminator == ItemType.Movie.ToString()).Any())
                {
                    filteredMovies.Add(m);
                }
            }

            return filteredMovies;
        }

        public Event GetMovieEvent(int eventId)
        {
            return context.Events.FirstOrDefault(x => x.EventId == eventId && x.Discriminator == ItemType.Movie.ToString());
        }

        public IEnumerable<Restaurant> GetFoodFilmRestaurants()
        {
            return context.Restaurants.Where(x => x.FoodFilm == true);
        }
    }
}