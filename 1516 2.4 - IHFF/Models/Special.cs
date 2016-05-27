using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Special : Event
    {
        public string Name { get; set; }
        public override TimeSpan Duration { get; set; }

        public override string ExtraInfo { get; set; }

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