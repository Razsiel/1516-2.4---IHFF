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

        // Get unique movie titles -> new list
        // for each unique movie get all the events associated with it
        public IEnumerable<Movie> GetAllMovies()
        {
            List<Movie> allMovie = context.Movies.ToList();
            //List<Movie> uniqueTitles = context.Movies.ToList().GroupBy(m => m.Title).Select(grp => grp.First()).ToList();

            List<Movie> allMovies = context.Movies.Where(s => s.Discriminator == "M").ToList().GroupBy(m => m.Title).Select(grp => grp.First()).ToList();
            
            foreach (Movie m in allMovies)
            {
                m.Airings = allMovie.Where(x => x.Title == m.Title);
                // Deze geeft foutmelding --> m.Airings = context.Events.Where(s => s.Discriminator == "M" && s.EventId == m.EventId).ToList();
                
            }

            return allMovies;
        }

        public Movie GetMovie(int id)
        {
            return context.Movies.FirstOrDefault(a => a.EventId == id);
        }

        //Get all movies
        //Filter based on event date
        //Set all movie airings
        public IEnumerable<Movie> GetMovies(int dayOfWeek)
        {
            if(dayOfWeek < 0)
            {
                return context.Movies;
            }

            IEnumerable<Movie> movies = context.Movies.ToList().Where(a => a.Date.DayOfWeek == (DayOfWeek)dayOfWeek);
            /*List<Movie> movies = new List<Movie>();
            foreach (Event airing in airings)
            {
                movies.Add(context.Movies.Where(m => m.EventId == airing.EventId).SingleOrDefault());
            }*/

            return movies;
        }
    }
}