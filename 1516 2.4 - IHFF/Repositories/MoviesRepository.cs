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

        // Get unique movie titles -> new list
        // for each unique movie get all the events associated with it
        public IEnumerable<Movie> GetAllMovies()
        {
            List<Movie> allMovies = context.Movies.ToList();
            List<Movie> uniqueTitles = allMovies.GroupBy(m => m.Title).Select(grp => grp.First()).ToList();

            foreach (Movie m in uniqueTitles)
            {
                m.Airings = allMovies.Where(x => x.Title == m.Title);
            }
            
            return uniqueTitles;
        }

        public Movie GetMovie(int id)
        {
            return null;// context.Movies.SingleOrDefault(a => a.EventId == id);
        }
    }
}