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
                    return string.Format("{0}, {1}-{2}, {3}", Date.DayOfWeek, Date.ToShortTimeString(), (Date.TimeOfDay.Add(Duration)), LocationString);
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