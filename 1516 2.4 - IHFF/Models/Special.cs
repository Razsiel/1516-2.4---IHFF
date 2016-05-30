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
    }
}