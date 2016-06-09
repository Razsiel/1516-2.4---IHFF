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
        public IEnumerable<Movie> GetAllUniqueMovies()
        {
            List<Movie> allMovies = context.Movies.Where(s => s.Discriminator == "M").ToList().GroupBy(m => m.Title).Select(grp => grp.First()).ToList();
             // testzin
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

            foreach (Movie movie in allMovies)
            {
                List<Movie> airings = new List<Movie>();
                IEnumerable<Movie> t = events.Where(x => x.EventId == movie.EventId);
                foreach (Movie m in t)
                {
                    if (!airings.Exists(x => x.EventId == m.EventId && x.Date == m.Date && x.LocationId == m.LocationId))
                    {
                        airings.Add(m);
                    }
                }
                movie.Airings = airings;
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

            //IEnumerable<Movie> movies = context.Movies.ToList().Where(a => a.Date.DayOfWeek == (DayOfWeek)dayOfWeek);

            List<Movie> allMovies = context.Movies.Where(s => s.Discriminator == "M").ToList().GroupBy(m => m.Title).Select(grp => grp.First()).ToList();

            /*
            DateTime firstSunday = new DateTime(1753, 1, 7);

            var temp = from Movie in context.Movies
                       join Event in context.Events
                             on new { Movie.EventId, Discriminator = "M" }
                         equals new { Event.EventId, Event.Discriminator}
                       where System.Data.Entity.DbFunctions.DiffDays(firstSunday, Event.Date) % 7 == dayOfWeek
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

            //foreach (Movie m in allMovies)
            //{
            //    m.Airings = events.Where(x => x.EventId == m.EventId);
            //}
            */

            //VIABLE replacement method instead of LINQ query 'temp'
            List<Movie> dayEvents = new List<Movie>();
            foreach (Movie movie in allMovies)
            {
                foreach (Event e in movie.Airings)
                {
                    if ((int)e.Date.DayOfWeek == dayOfWeek)
                    {
                        if (!dayEvents.Exists(x => x.Date == e.Date && x.EventId == e.EventId && x.LocationId == e.LocationId))
                        {
                            dayEvents.Add(e as Movie);
                        }
                    }
                }
            }


            return dayEvents;
        }

        public Movie GetMovieEvent(DateTime date, int eventId, int locationId)
        {
            var temp = from Movie in context.Movies
                       join Event in context.Events
                             on new { Movie.EventId, Discriminator = "M" }
                         equals new { Event.EventId, Event.Discriminator }
                       where
                           Event.EventId == eventId &&
                           Event.LocationId == locationId &&
                           Event.Date == date
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

            var t = temp.FirstOrDefault();

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

            //Get tracked event instead of new object Event... this gives an update error from EF when trying to save
            Movie e = events.Where(x => x.EventId == t.EventId && x.Date == t.Date && x.LocationId == t.LocationId).FirstOrDefault();

            return e;
        }
    }
}