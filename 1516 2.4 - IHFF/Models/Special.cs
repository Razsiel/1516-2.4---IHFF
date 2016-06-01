using IHFF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Special : Event
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string ExtraInfo { get; set; }

        public Special(string name, TimeSpan duration, string extraInfo)
        {
            this.Name = name;
            this.Duration = duration;
            this.ExtraInfo = extraInfo;
        }

        public Special() { }

        public override string GetName()
        {
            return this.Name;
        }

        public override string GetImage()
        {
            return "";
        }

        public string GetLocationString()
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("nl-NL");
            return string.Format("{0}, {1}-{2}, {3}", culture.DateTimeFormat.GetDayName(Date.DayOfWeek),
            DateTimeHelper.Round(Date).ToString("HH:mm"),
            DateTimeHelper.Round((Date.Add(Duration))).ToString("HH:mm"), LocationString);
        }

        public override decimal GetPrice()
        {
            return 0;
        }
    }
}