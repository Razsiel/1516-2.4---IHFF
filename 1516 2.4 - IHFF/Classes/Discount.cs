using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Classes
{
    public abstract class Discount
    {
        public decimal Percentage { get; set; }
        public string Description { get; set; }
    }
}