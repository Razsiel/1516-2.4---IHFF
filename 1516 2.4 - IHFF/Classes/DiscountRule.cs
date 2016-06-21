using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF
{
    public abstract class DiscountRule
    {
        public decimal Percentage { get; set; }
        public string Description { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public WishlistItem DiscountEvent { get; internal set; }
    }
}