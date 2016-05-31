using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IHFF.Helpers;

namespace IHFF.Models
{
    [Table("Event")]
    public abstract class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }

        //public virtual string ExtraInfo { get; set; }
        public string Discriminator { get; set; }


        //public virtual TimeSpan Duration { get; set; }
        public virtual Location Location { get; set; }

        public string AiringString
        {
            get
            {
                if (Location != null)
                {
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("nl-NL");
                    return string.Format("{0}, {1}-{2}, {3}", culture.DateTimeFormat.GetDayName(Date.DayOfWeek), 
                        DateTimeHelper.Round(Date).ToString("HH:mm"),
                        DateTimeHelper.Round((Date.Add((this as Movie).Duration))).ToString("HH:mm"), LocationString);
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
                    return DateTimeHelper.Round((Date.Add((this as Movie).Duration))).ToString("HH:mm");
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
                    return culture.DateTimeFormat.GetDayName(Date.DayOfWeek);
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

        public abstract string GetName();
        public abstract string GetImage();
    }
}