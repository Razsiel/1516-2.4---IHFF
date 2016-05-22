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

        public int Movie_Id { get; set; }
        public int Location_Id { get; set; }
        public int ActivityTypes_Id { get; set; }
        public DateTime ActivityDate { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Location Location { get; set; }

        public string AiringString
        {
            get
            {
                if (Location != null)
                {
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("nl-NL");
                    return string.Format("{0}, {1}-{2}, {3}", culture.DateTimeFormat.GetDayName(ActivityDate.DayOfWeek), 
                        RoundTheTime(ActivityDate).ToString("HH:mm"), 
                        RoundTheTime((ActivityDate.Add(Movie.Duration))).ToString("HH:mm"), LocationString);
                }
                return null;
            }
        }

        public override string LocationString
        {
            get
            {
                if (Location != null)
                {
                    return string.Format("{0}, {1}", Location.Name, Location.Room);
                }
                return null;
            }
        }

        // A method to round up or down the minutes for 
        public DateTime RoundTheTime(DateTime dt)
        {
            if ((dt.Minute % 10) >= 5)
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