using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class ViewModelMovie
    {
        public ViewModelMovie(Movie movie)
        {
            this.Movie = movie;
            Events = new List<Event>();
        }

        public Movie Movie { get; set; }
        public List<Event> Events { get; set; }
    }
}