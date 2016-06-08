using IHFF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Special
    {
        public Special() { }

        public int SpecialId { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string ExtraInfo { get; set; }

        public virtual ICollection<Event> Airings { get; set; }

        public string GetLocationString()
        {
            Event e = Airings.Where(x => x.Discriminator == ItemType.Special.ToString()).FirstOrDefault();
            return string.Format("{0}, {1}-{2}, {3}", Globals.CurrentCulture.DateTimeFormat.GetDayName(e.Date.DayOfWeek),
            DateTimeHelper.Round(e.Date).ToString("HH:mm"),
            DateTimeHelper.Round((e.Date.Add(Duration))).ToString("HH:mm"), e.LocationString);
        }
    }
}