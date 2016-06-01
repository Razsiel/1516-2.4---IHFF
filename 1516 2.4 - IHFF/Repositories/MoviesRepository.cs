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
            List<Movie> allMovies = context.Movies.Where(s => s.Discriminator == "M").ToList().GroupBy(m => m.Title).Select(grp => grp.First()).ToList();
            //IEnumerable<IGrouping<string, Event>> groups = context.Events.Where(s => s.Discriminator == "M").ToList().GroupBy(m => m.GetName());

            /*List<Movie> temp = context.Movies.Where(s => s.Discriminator == "M").ToList();

            List<Movie> allMovies = new List<Movie>();

            foreach(Movie m in temp)
            {
                if (allMovies.Any(item => item.EventId == m.EventId))
                {
                    //Movie movie = allMovies.First(item => item.EventId == m.EventId);
                }
                else
                    allMovies.Add(m);
            }

            foreach (Movie m in allMovies)
            {
                List<Event> airings = new List<Event>();
                foreach (Event e in temp)
                {
                    if (m.Title == e.GetName())
                    {
                        airings.Add(e);
                    }
                }
                m.Airings = airings;
            }

            /*foreach (Movie m in allMovies)
            {
                IEnumerable<IGrouping<string, Event>> events = groups.Where(x => x.Key == m.Title);
                m.Airings = events.SelectMany(grp => grp);
            }*/

            /* var temp = from Event in context.Events
                       where
                         Event.Discriminator == "M"
                       select new
                       {
                           EventId = Event.EventId,
                           Date = Event.Date,
                           LocationId = Event.LocationId,
                           Discriminator = Event.Discriminator
                       }; */

            var temp = from Movie in context.Movies
            join Event in context.Events
                  on new { Movie.EventId, Discriminator = "M" }
              equals new { Event.EventId, Event.Discriminator }
            select new
            {
                EventId = Movie.EventId,
                Title = Movie.Title,
                Director = Movie.Director,
                YearOfRelease = Movie.YearOfRelease,
                IMDBRating = Movie.IMDBRating,
                Actors = Movie.Actors,
                Description = Movie.Description,
                IMDBUrl = Movie.IMDBUrl,
                Image = Movie.Image,
                ExtraInfo = Movie.ExtraInfo,
                Duration = Movie.Duration,
                Description_NL = Movie.Description_NL,
                Price = Movie.Price,
                YoutubeLink = Movie.YoutubeLink,
                Date = Event.Date,
                LocationId = Event.LocationId,
                Discriminator = Event.Discriminator
            };




            List<Movie> events = new List<Movie>();
            foreach (var item in temp)
            {
                Movie m = new Movie(
                    item.EventId,
                    item.Date,
                    item.LocationId,
                    item.Discriminator,
                    item.Title,
                    item.Director, 
                    item.YearOfRelease, 
                    item.IMDBRating, 
                    item.Actors, 
                    item.Description,
                    item.IMDBUrl, 
                    item.Image, 
                    item.ExtraInfo, 
                    item.Duration, 
                    item.Description_NL, 
                    item.Price,
                    item.YoutubeLink);
                m.Location = context.Locations.FirstOrDefault(x => x.LocationId == m.LocationId);

                events.Add(m);
            }

            foreach (Movie m in allMovies)
            {
                m.Airings = events.Where(x => x.EventId == m.EventId);
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