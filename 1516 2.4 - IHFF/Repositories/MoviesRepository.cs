using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;
using IHFF.Interfaces;

namespace IHFF.Repositories
{
    public class MoviesRepository : IMovieRepository
    {
        private IHFFContext context = IHFFContext.Instance;

        // A method to round up or down the minutes
        public static DateTime Round(DateTime dt)
        {
            if((dt.Minute % 10) >= 5)
            {
                return dt.AddMinutes((60 - dt.Minute) % 10);
            }
            else
            {
                return dt.AddMinutes(-dt.Minute % 10);
            }
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            List<Movie> Movies = context.Movies.ToList();
            List<Event> Events = context.Events.ToList();
            List<EventItem> EventItems = context.EventItems.ToList();

            List<Event> ofTypeEvent = context.Movies.OfType<Event>().ToList();
            List<Movie> ofTypeMovie = context.Events.OfType<Movie>().ToList();

            return Movies;
        }

        public Event GetEvent(int id)
        {
            return context.Events.SingleOrDefault(e => e.EventId == id);
        }

        public Movie GetMovie(int id)
        {
            return context.Movies.SingleOrDefault(a => a.EventId == id);
        }
    }
}