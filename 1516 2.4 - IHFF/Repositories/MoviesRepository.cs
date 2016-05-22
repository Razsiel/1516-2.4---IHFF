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

        /*
        public IEnumerable<MoviesViewModel> GetAllMovies()
        {
            // Get the dutch culture
            var culture = new System.Globalization.CultureInfo("nl-NL");

            // Lijst van alle films ophalen
            IEnumerable<Movie> allMovies = context.Movies;
            
            // MovieViewModel klaarzetten
            List<MoviesViewModel> movies = new List<MoviesViewModel>();

            foreach(Movie movie in allMovies)
            {
                IEnumerable<Airing> test = context.Airings.Where(c => c.Movie_Id == movie.Id);
                List<AiringItem> airings = new List<AiringItem>();

                foreach (Airing t in test)
                {
                    string locationName = context.Locations.SingleOrDefault(x => x.Id == t.Location_Id).Name;
                    string locationRoom = context.Locations.SingleOrDefault(x => x.Id == t.Location_Id).Room;
                    string location = locationName + " " + locationRoom;
                    string airingText = String.Format("{0}, {1} - {2}, {3}", culture.DateTimeFormat.GetDayName(t.Date.DayOfWeek), t.Date.ToString("HH:mm"), Round(t.Date + movie.Duration).ToString("HH:mm"), location);
                    AiringItem airingItem = new AiringItem(t.Id, airingText);
                    airings.Add(airingItem);
                }

                movies.Add(new MoviesViewModel(movie.Id, movie.Image, movie.Title, movie.Description_NL, movie.Director,
                    movie.YearOfRelease, movie.Price, airings));
            }

            return movies;
        }
        */
        
        /*
        public AiringItem GetAiringItem(int id, int amount)
        {
            // Get the dutch culture
            var culture = new System.Globalization.CultureInfo("nl-NL");

            Airing airing = context.Airings.Where(x => x.Id == id).SingleOrDefault();

            string locationName = context.Locations.SingleOrDefault(x => x.Id == airing.Location_Id).Name;
            string locationRoom = context.Locations.SingleOrDefault(x => x.Id == airing.Location_Id).Room;
            string dayOfWeek = culture.DateTimeFormat.GetDayName(airing.Date.DayOfWeek);

            decimal price = context.Movies.SingleOrDefault(x => x.Id == airing.Movie_Id).Price * amount;

            TimeSpan duration = context.Movies.SingleOrDefault(x => x.Id == airing.Movie_Id).Duration;
            TimeSpan endTime = Round(airing.Date + duration).TimeOfDay;

            return new AiringItem(airing.Id, locationName, locationRoom, airing.Date.TimeOfDay, endTime, dayOfWeek, amount, price);
        }
        */

        public Airing GetAiring(int id)
        {
            return context.Airings.Where(a => a.Id == id).SingleOrDefault();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return context.Movies;
        }

        public Movie GetMovie(int id)
        {
            return context.Movies.SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<Movie> GetMovies(int dayOfWeek)
        {
            if(dayOfWeek < 0)
            {
                return context.Movies;
            }

            IEnumerable<Airing> airings = context.Airings.ToList().Where(a => a.ActivityDate.DayOfWeek == (DayOfWeek)dayOfWeek);
            List<Movie> movies = new List<Movie>();
            foreach (Airing airing in airings)
            {
                movies.Add(context.Movies.Where(a => a.Id == airing.Movie_Id).SingleOrDefault());
            }

            return movies;
        }
    }
}