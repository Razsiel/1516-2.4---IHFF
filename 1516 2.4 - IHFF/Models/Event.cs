using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("Event")]
    public abstract class Event
    {
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
        public string ExtraInfo { get; set; }

        [NotMapped]
        public abstract TimeSpan Duration { get; set; }
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

        public string EndTime
        {
            get
            {
                if(Location != null)
                {
                    return RoundTheTime((ActivityDate.Add(Movie.Duration))).ToString("HH:mm");
                }
                return null;
            }
        }

        public string DayName
        {
            get
            {
                if (Location != null){
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("nl-NL");
                    return culture.DateTimeFormat.GetDayName(ActivityDate.DayOfWeek);
                }
                return null;
            }
        }
        public string LocationString
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

        public abstract string GetName();
        public abstract string GetImage();
    }
}