using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    [Table("Airings")]
    public class Airing : ActivityType
    {
        public Airing() { }

        public Airing(int id, DateTime date, int movieId, int locationId, int activityType)
        {
            this.Id = id;
            this.Date = date;
            this.Movie_Id = movieId;
            this.Location_Id = locationId;
            this.ActivityTypes_Id = activityType;
            this.Name = Movie.Title;
        }

        public int Movie_Id { get; set; }
        public int Location_Id { get; set; }
        public int ActivityTypes_Id { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Location Location { get; set; }

        public string AiringString
        {
            get
            {
                if (Location != null)
                {
                    return string.Format("{0}, {1}-{2}, {3} {4}", Date.DayOfWeek, Date.ToShortTimeString(), (Date.TimeOfDay.Add(Movie.Duration)), Location.Name, Location.Room);
                }
                return null;
            }
        }
    }
}