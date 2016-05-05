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
    }
}